using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsBet.Models;
using Microsoft.Extensions.Configuration;

namespace LetsBet.BusinessServices
{
    public interface ICustomerBusinessServices : IBaseBusinessService<Customer>
    {
        IEnumerable<CustomerRisk> GetCustomerRiskReport();
    }

    public class CustomerBusinessServices : BaseBusinessServices<Customer>, ICustomerBusinessServices
    {
        private IHttpClientManager _httpClientManager;
        private IConfiguration _configuration;
        private IBetBusinessServices _betBusinessServices;
        public CustomerBusinessServices(IHttpClientManager httpClientManager, IConfiguration configuaration, IBetBusinessServices betBusinessServices) : base(httpClientManager, configuaration)
        {
            _httpClientManager = httpClientManager;
            _configuration = configuaration;
            _betBusinessServices = betBusinessServices;
        }

        public override void SetApiEndpointAddress()
        {
            ApiEndPoint = _configuration.GetSection("ApiEndPoint")["Customers"];
        }

        public IEnumerable<CustomerRisk> GetCustomerRiskReport()
        {
            var allCustomers = GetAll();

            return (from customer in allCustomers
                let customerBets = _betBusinessServices.GetAll().Where(x => x.CustomerId == customer.Id)
                select new CustomerRisk
                {
                    Customer = customer,
                    BetAmount = customerBets.Sum(x => x.Stake),
                    BetCount = customerBets.Count(),
                    InHiRisk = customerBets.Sum(x => x.Stake) >= 200.00m
                }).ToList();
        }
    }

}
