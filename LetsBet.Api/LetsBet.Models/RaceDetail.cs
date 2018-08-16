using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LetsBet.Models
{
    public class RaceDetail
    {
        public RaceDetail(Race race, IEnumerable<Bet> bets)
        {
            Race = race;
            if (bets != null)
            {
                Bets = bets;
            }
        }

        public Race Race { get; set; }
        public decimal RaceTotalBet => Bets?.Sum(x => x.Stake) ?? 0.0m;
        public IEnumerable<Bet> Bets { get; set; }
        public IEnumerable<HorseRace> HorseRaces { get; set; }
    }
}
