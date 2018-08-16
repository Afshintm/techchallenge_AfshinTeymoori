using System.Collections.Generic;
using System.Linq;
using LetsBet.Models;
using Microsoft.Extensions.Configuration;

namespace LetsBet.BusinessServices
{
    public interface IBetBusinessServices : IBaseBusinessService<Bet>
    {
        IEnumerable<Bet> GetBetsforRace(int raceId);
    }

    public class BetBusinessServices : BaseBusinessServices<Bet>, IBetBusinessServices
    {
        private IConfiguration _configuration;
        public BetBusinessServices(IHttpClientManager httpClientManager, IConfiguration configuration) : base(httpClientManager, configuration)
        {
            _configuration = configuration;
        }

        public override void SetApiEndpointAddress()
        {
            ApiEndPoint = _configuration.GetSection("ApiEndPoint")["Bets"];
        }

        public IEnumerable<Bet> GetBetsforRace(int raceId)
        {
            return GetAll().Where(x => x.RaceId == raceId);
        }
    }
}
