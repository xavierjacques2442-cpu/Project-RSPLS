using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Project_RSPLS.Models;

namespace Project_RSPLS.Service
{
    public class ServiceOne
    {
        private readonly Random Random = new();
        
        private static readonly Dictionary<string, Dictionary<string, string>> Rules = new()
        {
            ["Rock"] = new Dictionary<string, string>
            {
                ["Scissors"] = "Rock crushes Scissors",
                ["Lizard"] = "Rock crushes Lizard"
            },
            ["Paper"] = new Dictionary<string, string>
            {
                ["Rock"] = "Paper covers Rock",
                ["Spock"] = "Paper disproves Spock"
            },
            ["Scissors"] = new Dictionary<string, string>
            {
                ["Paper"] = "Scissors cuts Paper",
                ["Lizard"] = "Scissors decapitates Lizard"
            },
            ["Lizard"] = new Dictionary<string, string>
            {
                ["Spock"] = "Lizard poisons Spock",
                ["Paper"] = "Lizard eats Paper"
            },
            ["Spock"] = new Dictionary<string, string>
            {
                ["Scissors"] = "Spock smashes Scissors",
                ["Rock"] = "Spock vaporizes Rock"
            }
        };

        private static readonly List<string> Moves = new(Rules.Keys);
        
        public string GetCpuMove() => Moves[Random.Next(Moves.Count)];
        
       

        public GameResult PlayCpuRound(string playerMove)
        {
         if (string.IsNullOrWhiteSpace(playerMove))
            {
                return new GameResult
                {
                    Result = "invalid",
                    Reason = "Player move cannot be empty." 
                };
            }
            playerMove = char.ToUpper(playerMove[0]) + playerMove.Substring(1).ToLower();

            if (!Rules.ContainsKey(playerMove))
            {
                return new GameResult
                {
                    Result = "invalid",
                    Reason = "Invalid move. Valid moves are: Rock, Paper, Scissors, Lizard, Spock."
                };
            }
            var cpuMove = GetCpuMove();
            if (playerMove == cpuMove)
            {
                return new GameResult
                {
                    Move = playerMove,
                    cpuMove = cpuMove,
                    Result = "tie",
                    Reason = "Both players selected the same move."
                };
            }
            if (Rules[playerMove].ContainsKey(cpuMove))
            {
                return new GameResult
                {
                    Move = playerMove,
                    cpuMove = cpuMove,
                    Result = "win",
                    Reason = Rules[playerMove][cpuMove]
                };
            }
            else
            {
                return new GameResult
                {
                    Move = playerMove,
                    cpuMove = cpuMove,
                    Result = "lose",
                    Reason = Rules[cpuMove][playerMove]
                };

            }
        }

           public Matches playMatchRound(Matches match, string playerMove)
           {
            var roundResult = PlayCpuRound(playerMove);
            if (roundResult.Result == "win")
            {
                match.PlayerScore++;
            }
            else if (roundResult.Result == "lose")
            {
                match.CpuScore++;
            }
            return match;
        }
}
}
