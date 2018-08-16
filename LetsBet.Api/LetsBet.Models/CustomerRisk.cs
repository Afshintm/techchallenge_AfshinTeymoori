using System;
using System.Collections.Generic;
using System.Text;

namespace LetsBet.Models
{
    public class CustomerRisk
    {
        public Customer Customer { get; set; }
        public int BetCount { get; set; }
        public decimal BetAmount { get; set; }
        public bool InHiRisk { get; set; }
    }
}
