using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
