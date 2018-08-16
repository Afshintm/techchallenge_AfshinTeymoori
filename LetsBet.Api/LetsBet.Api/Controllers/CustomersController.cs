using System.Collections.Generic;
using System.Linq;
using LetsBet.BusinessServices;
using LetsBet.Models;
using Microsoft.AspNetCore.Mvc;

namespace LetsBet.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : Controller
    {
        private ICustomerBusinessServices _customerBusinessServices;
        public CustomersController(ICustomerBusinessServices customerBusinessServices)
        {
            _customerBusinessServices = customerBusinessServices;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            var customers = _customerBusinessServices.GetAll();
            return customers;
        }
        [HttpGet]
        [Route("Risks")]
        public List<CustomerRisk> GetCustomerRisks()
        {
            var result = _customerBusinessServices.GetCustomerRiskReport();
            return result.ToList();
        }

    }
}