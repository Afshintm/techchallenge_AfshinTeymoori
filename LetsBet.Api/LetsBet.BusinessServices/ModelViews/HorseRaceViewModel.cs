using System;
using System.Collections.Generic;
using System.Text;

namespace LetsBet.BusinessServices.ModelViews
{
    public class HorseRaceViewModel
    {
        public int HorseId { get; set; }
        public string HorseName { get; set; }
        public int RaceId { get; set; }
        public int NumberOfBets { get; set; }
        public decimal TotalBet { get; set; }
        public decimal OwingOnWin { get; set; }
    }
}
