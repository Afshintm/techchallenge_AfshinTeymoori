using System;
using System.Collections.Generic;
using System.Text;

namespace LetsBet.Models
{
    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public string Status { get; set; }
        public List<Horse> Horses { get; set; }
    }
}
