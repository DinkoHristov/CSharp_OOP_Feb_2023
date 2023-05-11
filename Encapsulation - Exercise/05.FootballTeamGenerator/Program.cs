using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] teamInfo = input.Split(";", StringSplitOptions.RemoveEmptyEntries);
                string commandType = teamInfo[0];

                try
                {
                    if (commandType == "Team")
                    {
                        string teamName = teamInfo[1];

                        Team team = new Team(teamName);

                        teams.Add(team);
                    }
                    else if (commandType == "Add")
                    {
                        string teamName = teamInfo[1];
                        string playerName = teamInfo[2];
                        int endurance = int.Parse(teamInfo[3]);
                        int sprint = int.Parse(teamInfo[4]);
                        int dribbling = int.Parse(teamInfo[5]);
                        int passing = int.Parse(teamInfo[6]);
                        int shooting = int.Parse(teamInfo[7]);

                        if (teams.Any(t => t.Name == teamName))
                        {
                            Team team = teams.FirstOrDefault(t => t.Name == teamName);

                            Player player = 
                                new Player(playerName, endurance, sprint, dribbling, passing, shooting);

                            team.AddPlayer(player);
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }

                    }
                    else if (commandType == "Remove")
                    {
                        string teamName = teamInfo[1];
                        string playerName = teamInfo[2];

                        if (teams.Any(t => t.Name == teamName))
                        {
                            Team team = teams.FirstOrDefault(t => t.Name == teamName);

                            team.RemovePlayer(playerName);
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                    else if (commandType == "Rating")
                    {
                        string teamName = teamInfo[1];

                        if (teams.Any(t => t.Name == teamName))
                        {
                            Team team = teams.FirstOrDefault(t => t.Name == teamName);

                            Console.WriteLine($"{teamName} - {team.Rating:F0}");
                        }
                        else
                        {
                            Console.WriteLine($"Team {teamName} does not exist.");
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }

        }
    }
}
