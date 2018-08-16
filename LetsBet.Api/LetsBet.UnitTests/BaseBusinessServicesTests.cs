using System;
using System.Collections.Generic;
using LetsBet.Models;

namespace LetsBet.UnitTests
{
    public class BaseBusinessServicesTests
    {
        public List<Customer> Customers { get; set; }
        public List<Bet> Bets { get; set; }
        public List<Race> Races { get; set; }

        public void Setup()
        {
            initFakes();
        }

        private void initFakes()
        {
            Customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Customer1"},
                new Customer {Id = 2, Name = "Customer2"}
            };
            Bets = new List<Bet>
            {
                new Bet {CustomerId = 1, RaceId = 1, Stake = 150.0m, HorseId = 1},
                new Bet {CustomerId = 1, RaceId = 2, Stake = 100.0m, HorseId = 1},
                new Bet {CustomerId = 2, RaceId = 1, Stake = 50.0m, HorseId = 1},
                new Bet {CustomerId = 2, RaceId = 2, Stake = 100.0m, HorseId = 1},
                new Bet {CustomerId = 1, RaceId = 1, Stake = 150.0m, HorseId = 1},
                new Bet {CustomerId = 1, RaceId = 2, Stake = 100.0m, HorseId = 1},
            };
            Races = new List<Race>
            {
                new Race
                {
                    Id = 1,
                    Start = DateTime.Now.AddMinutes(-1),
                    Status = "InProgress",
                    Horses = new List<Horse>
                    {
                        new Horse {Id = 1, Name = "Horse1", Odds = 1.5m},
                        new Horse {Id = 2, Name = "Horse2", Odds = 3.5m},
                        new Horse {Id = 3, Name = "Horse3", Odds = 5.0m}
                    }
                },
                new Race
                {
                    Id = 2,
                    Start = DateTime.Now.AddDays(1),
                    Status = "Pending",
                    Horses = new List<Horse>
                    {
                        new Horse {Id = 1, Name = "Horse1", Odds = 0.5m},
                        new Horse {Id = 2, Name = "Horse2", Odds = 0.3m},
                        new Horse {Id = 3, Name = "Horse3", Odds = 0.7m}
                    }
                }
            };
        }
    }
}
