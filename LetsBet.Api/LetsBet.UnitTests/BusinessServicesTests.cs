using System;
using System.Linq;
using LetsBet.BusinessServices;
using NUnit.Framework;

namespace LetsBet.UnitTests
{
    [TestFixture]
    class BusinessServicesTests : BaseBusinessServicesTests
    {
        [Test]
        public void CustomerListHasValue()
        {
            var customerBusinessService = new CustomerBusinessServices(HttpClientManagerMock.Object, ConfigurationMock.Object, BetBusinessServices);
            var customers = customerBusinessService.GetAll();
            Assert.NotNull(customers);
        }

        [Test]
        public void RaceBusinessServices_GetRaceDetailsV1_Should_Enumerate()
        {
            var raceBusinessServices = new RaceBusinessServices(HttpClientManagerMock.Object, ConfigurationMock.Object, BetBusinessServices);
            var result = raceBusinessServices.GetRaceDetailsV1().ToList();
            Assert.NotNull(result);
        }
    }
}
