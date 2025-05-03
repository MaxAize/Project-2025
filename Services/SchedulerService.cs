using final_project.Models;
using final_project.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;

namespace final_project.Services
{
    public class SchedulerService
    {
        private readonly GameRepository gameRepo = new GameRepository();
        private readonly RefereeRepository refereeRepo = new RefereeRepository();
        private readonly AssignmentResultRepository assignmentRepo = new AssignmentResultRepository();
        private List<AssignmentResult> assignedResults;
        private List<AssignmentResult> bestResults;
        private List<List<AssignmentResult>> tabuList;
        private int maxIterations = 100;
        private int tabuListSize = 10;

        public SchedulerService()
        {
            assignedResults = new List<AssignmentResult>();
            bestResults = new List<AssignmentResult>();
            tabuList = new List<List<AssignmentResult>>();
        }

        public List<AssignmentResult> AssignedResults => assignedResults;

        public void GenerateInitialAssignments()
        {
            assignedResults.Clear();
            var games = gameRepo.GetAllGames().OrderByDescending(g => g.ImportanceRating).ToList();
            var referees = refereeRepo.GetAllReferees();

            foreach (var game in games)
            {
                AssignRefereesToGame(game, referees);
            }

            bestResults = new List<AssignmentResult>(assignedResults);
        }

        private void AssignRefereesToGame(Game game, List<Referee> referees)
        {
            var eligibleReferees = GetEligibleReferees(game, referees);

            var selected = eligibleReferees
                .OrderByDescending(r => r.YearsOfExperience)
                .ThenBy(r => r.License)
                .Take(GetRefereeCount(game))
                .ToList();

            selected.ForEach(referee =>
                assignedResults.Add(new AssignmentResult { Game = game, Referee = referee }));

            // Save assignment results to the database after generating initial assignments
            SaveAssignmentsToDatabase(selected, game);
        }

        // New method to save assignments to the database
        private void SaveAssignmentsToDatabase(List<Referee> selectedReferees, Game game)
        {
            foreach (var referee in selectedReferees)
            {
                AssignmentResult assignmentResult = new AssignmentResult
                {
                    Game = game,
                    Referee = referee
                };
                assignmentRepo.AddAssignmentResult(assignmentResult); // Save to DB
            }
        }

        private List<Referee> GetEligibleReferees(Game game, List<Referee> referees)
        {
           return referees.Where(referee => IsEligible(referee, game)).ToList();
        }

        private bool IsEligible(Referee referee, Game game)
        {
            bool validLicense = HasValidLicense(referee, game.ImportanceRating);
            bool available = IsAvailable(referee, game);

            return validLicense && available;
        }

        private bool HasValidLicense(Referee referee, int importance)
        {
            return (referee.License == LicenseType.A) ||
                   (referee.License == LicenseType.B && importance <= 2000) ||
                   (referee.License == LicenseType.C && importance <= 1000);
        }

        private bool IsAvailable(Referee referee, Game game)
        {
            return referee.Availability.Any(a => a.Day == game.DateTime.DayOfWeek &&
                                                  a.StartTime <= game.DateTime.TimeOfDay &&
                                                  a.EndTime >= game.DateTime.TimeOfDay);
        }

        private int GetRefereeCount(Game game)
        {
            if (game.League == LeagueType.First)
            {
                return 3;
            }
            else if (game.League == LeagueType.Second)
            {
                return game.IsPlayoff ? 3 : 2;
            }
            else
            {
                return game.IsPlayoff ? 2 : 1;
            }
        }

        public void PerformTabuSearch()
        {
            int iteration = 0;
            int iterationWithoutImprovement = 0;

            while (iteration < maxIterations && iterationWithoutImprovement < 10)
            {
                var neighbors = GenerateNeighbors();
                var bestNeighbor = GetBestNeighbor(neighbors);

                if (IsBetterSolution(bestNeighbor, bestResults))
                {
                    bestResults = new List<AssignmentResult>(bestNeighbor);
                    assignedResults = bestResults;
                    iterationWithoutImprovement = 0;
                }
                else
                {
                    iterationWithoutImprovement++;
                }

                tabuList.Add(bestNeighbor);
                if (tabuList.Count > tabuListSize)
                    tabuList.RemoveAt(0);

                iteration++;
            }
        }

        private List<List<AssignmentResult>> GenerateNeighbors()
        {
            var neighbors = new List<List<AssignmentResult>>();

            for (int i = 0; i < assignedResults.Count; i++)
            {
                for (int j = i + 1; j < assignedResults.Count; j++)
                {
                    var neighbor = new List<AssignmentResult>(assignedResults);
                    SwapReferees(neighbor, i, j);

                    if (!TabuListContains(neighbor))
                    {
                        neighbors.Add(neighbor);
                    }
                }
            }

            return neighbors;
        }

        private bool TabuListContains(List<AssignmentResult> neighbor)
        {
            return tabuList.Any(tabu => tabu.SequenceEqual(neighbor));
        }

        private void SwapReferees(List<AssignmentResult> neighbor, int i, int j)
        {
            var temp = neighbor[i];
            neighbor[i] = neighbor[j];
            neighbor[j] = temp;
        }

        private List<AssignmentResult> GetBestNeighbor(List<List<AssignmentResult>> neighbors)
        {
            if (neighbors == null || !neighbors.Any())
            {
                return bestResults;
            }

            return neighbors
                .Where(n => n != null)
                .OrderBy(n => CalculateObjectiveFunction(n))
                .First();
        }

        private bool IsBetterSolution(List<AssignmentResult> solution, List<AssignmentResult> currentBest)
        {
            return CalculateObjectiveFunction(solution) < CalculateObjectiveFunction(currentBest);
        }

        private int CalculateObjectiveFunction(List<AssignmentResult> solution)
        {
            int penalty = 0;

            if (solution == null || !solution.Any())
            {
                // Max penalty if no solution exists
                return int.MaxValue;
            }

            penalty += CalculateOutdoorMismatchPenalty(solution);
            penalty += CalculateOverloadedRefereePenalty(solution);
            penalty += CalculateConsecutiveAssignmentsPenalty(solution);

            return penalty;
        }

        private int CalculateOutdoorMismatchPenalty(List<AssignmentResult> solution)
        {
            return solution.Count(result => result.Referee.AcceptsOutdoorGames == false &&
                                             result.Game.Field == FieldType.Outdoor) * 10;
        }

        private int CalculateOverloadedRefereePenalty(List<AssignmentResult> solution)
        {
            var refereeAssignments = solution.GroupBy(a => a.Referee.ID)
                                              .Select(group => new { Referee = group.Key, Count = group.Count() })
                                              .ToList();

            return refereeAssignments.Where(a => a.Count > 3)
                                     .Sum(a => 20 * (a.Count - 3));
        }

        private int CalculateConsecutiveAssignmentsPenalty(List<AssignmentResult> solution)
        {
            var groupedByReferee = solution.GroupBy(a => a.Referee.ID)
                                           .Select(group => new
                                           {
                                               Referee = group.Key,
                                               Games = group.OrderBy(g => g.Game.DateTime).ToList()
                                           });

            return groupedByReferee.Sum(refereeGroup =>
                refereeGroup.Games.Zip(refereeGroup.Games.Skip(1), (g1, g2) =>
                    Math.Abs((g2.Game.DateTime - g1.Game.DateTime).TotalHours) < 6 ? 15 : 0).Sum());
        }
    }
}
