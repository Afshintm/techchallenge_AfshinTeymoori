using System;
using System.Collections.Generic;
using System.Text;

namespace LetsBet.Models
{
    public class Bet
    {
        public int CustomerId { get; set; }
        public int HorseId { get; set; }
        public int RaceId { get; set; }
        public decimal Stake { get; set; }
    }
}
