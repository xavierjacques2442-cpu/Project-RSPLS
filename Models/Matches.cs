using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_RSPLS.Models
{
    public class Matches
    {
        public int PlayerScore { get; set; }
        public int CpuScore { get; set; }

        public int RoundsNeededToWin { get; set; }
        
        public bool MatchOver => PlayerScore >= RoundsNeededToWin || CpuScore >= RoundsNeededToWin;
        
    }
}