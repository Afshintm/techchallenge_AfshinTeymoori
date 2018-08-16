using System;
using System.Collections.Generic;
using System.Text;

namespace LetsBet.BusinessServices.ModelViews
{
    public class RaceBetViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public decimal RaceTotalBet { get; set; }
        public List<HorseRaceViewModel> HorseRace { get; set; }
    }
}
