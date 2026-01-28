using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_RSPLS.Models
{
    public class MatchPlayRequest
    {
        public Matches Match { get; set; }
        public string PlayerMove { get; set; }
    }
}