using System;
using System.Collections.Generic;
using System.Text;

namespace LetsBet.Models
{
    public class RaceBets
    {
        public RaceBets()
        {
            Bets = new List<Bet>();
            HorseRaces = new List<HorseRace>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public decimal RaceTotalBet { get; set; }
        public List<Bet> Bets { get; set; }
        public List<HorseRace> HorseRaces { get; set; }
    }
}
