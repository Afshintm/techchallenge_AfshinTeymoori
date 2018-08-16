using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using LetsBet.BusinessServices;
using LetsBet.Models;
using Moq;
using NUnit.Framework;

namespace LetsBet.UnitTests
{
    [TestFixture]
    public class BaseBusinessServicesTests
    {
        public Mock<IHttpClientManager> HttpClientManagerMock;
        public Mock<IConfiguration> ConfigurationMock;
        public Mock<IBetBusinessServices> BetBusinessServicesMock;
        public Mock<ICustomerBusinessServices> CustomerBusinessServicesMock;
        public const string FakeApiEndpoint = "FakeApiEndpoin";

        public ICustomerBusinessServices CustomerBusinessServices;
        public IBetBusinessServices BetBusinessServices;
        

        public List<Customer> FakeCustomers { get; set; }
        public List<Bet> FakeBets { get; set; }
        public List<Race> FakeRaces { get; set; }
        [SetUp]
        public void Setup()
        {
            initFakes();
            ConfigurationMock = new Mock<IConfiguration>();
            ConfigurationMock.Setup(x => x.GetSection(It.IsAny<string>())[It.IsAny<string>()]).Returns(FakeApiEndpoint);
            HttpClientManagerMock = new Mock<IHttpClientManager>(MockBehavior.Default);
            HttpClientManagerMock.Setup(x => x.GetAsync<List<Customer>>(It.IsAny<string>())).Returns(() => Task.FromResult(FakeCustomers));
            HttpClientManagerMock.Setup(x => x.GetAsync<List<Bet>>(It.IsAny<string>())).Returns(() => Task.FromResult(FakeBets));
            HttpClientManagerMock.Setup(x => x.GetAsync<List<Race>>(It.IsAny<string>())).Returns(() => Task.FromResult(FakeRaces));
            
            BetBusinessServices = new BetBusinessServices(HttpClientManagerMock.Object, ConfigurationMock.Object);
            CustomerBusinessServices = new CustomerBusinessServices(HttpClientManagerMock.Object, ConfigurationMock.Object, BetBusinessServices);
            
        }

        private void initFakes()
        {
            FakeCustomers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Customer1"},
                new Customer {Id = 2, Name = "Customer2"}
            };
            FakeBets = new List<Bet>
            {
                new Bet {CustomerId = 1, RaceId = 1, Stake = 150.0m, HorseId = 1},
                new Bet {CustomerId = 1, RaceId = 2, Stake = 100.0m, HorseId = 1},
                new Bet {CustomerId = 2, RaceId = 1, Stake = 50.0m, HorseId = 1},
                new Bet {CustomerId = 2, RaceId = 2, Stake = 100.0m, HorseId = 1},
                new Bet {CustomerId = 1, RaceId = 1, Stake = 150.0m, HorseId = 1},
                new Bet {CustomerId = 1, RaceId = 2, Stake = 100.0m, HorseId = 1},
            };
            FakeRaces = new List<Race>
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
