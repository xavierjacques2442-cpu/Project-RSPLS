using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_RSPLS.Models;

namespace Project_RSPLS.Models
{
    public class GameResult
    {
          public string Move { get; set; }
        public string cpuMove { get; set; }

        public string Result { get; set; }

        public string Reason { get; set; }
    }
}