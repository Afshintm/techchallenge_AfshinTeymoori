using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetsBet.BusinessServices
{
    public interface IBaseBusinessService<T>
    {
        IEnumerable<T> GetAll();
        string ApiEndPoint { get; set; }
    }

    public abstract class BaseBusinessServices<T> : IBaseBusinessService<T> where T : class
    {

        private IHttpClientManager _httpClientManager;
        private IConfiguration _configuration;
        public string ApiEndPoint { get; set; }
        public BaseBusinessServices(IHttpClientManager httpClientManager, IConfiguration configuration)
        {
            _httpClientManager = httpClientManager;
            _configuration = configuration;
        }

        public abstract void SetApiEndpointAddress();
        //{
        //    throw new NotImplementedException();
        //}

        public virtual IEnumerable<T> GetAll()
        {
            SetApiEndpointAddress();
            if (string.IsNullOrEmpty(ApiEndPoint))
            {
                throw new ApplicationException($"No endpoint is provided.");
            }

            var result = Task.Run(async () => await _httpClientManager.GetAsync<List<T>>(ApiEndPoint)).Result;
            return result;

        }

    }
}
