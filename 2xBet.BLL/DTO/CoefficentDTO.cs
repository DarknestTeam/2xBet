﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.BLL.DTO
{
 public   class CoefficentDTO
    {
        public string CommandCoeff_Id { get; set; }
        public string CoeffWin { get; set; }
        public string CoeffLose { get; set; }
        public string CoeffDraw { get; set; }
        public int MatchId { get; set; }
    }
}
