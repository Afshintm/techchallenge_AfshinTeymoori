using System.Collections.Generic;
using System.Linq;
using LetsBet.Models;
using Microsoft.Extensions.Configuration;

namespace LetsBet.BusinessServices
{
    public interface IRaceBusinessServices : IBaseBusinessService<Race>
    {
        List<RaceBets> GetRaceDetails();
        IEnumerable<RaceDetail> GetRaceDetailsV1();
    }
    public class RaceBusinessServices : BaseBusinessServices<Race>, IRaceBusinessServices
    {
        private readonly IConfiguration _configuration;
        private readonly IBetBusinessServices _betServices;
        public RaceBusinessServices(
            IHttpClientManager httpClientManager,
            IConfiguration configuration,
            IBetBusinessServices betServices) : base(httpClientManager, configuration)
        {
            _configuration = configuration;
            _betServices = betServices;
        }

        public override void SetApiEndpointAddress()
        {
            ApiEndPoint = _configuration.GetSection("ApiEndPoint")["Races"];
        }

        public List<RaceBets> GetRaceDetails()
        {
            var result = new List<RaceBets>();
            var races = GetAll();
            var allBets = _betServices.GetAll().ToList();
            foreach (var race in races)
            {
                var raceDetails = new RaceBets { Id = race.Id, Status = race.Status, Name = race.Name };
                raceDetails.Bets = allBets.Where(x => x.RaceId == race.Id).ToList();
                raceDetails.RaceTotalBet = raceDetails.Bets.Sum(x => x.Stake);
                foreach (var horse in race.Horses)
                {
                    var thisRaceHorseBets = raceDetails.Bets.Where(x => x.HorseId == horse.Id).ToList();
                    var horseRace = new HorseRace
                    {
                        Horse = horse,
                        RaceId = race.Id,
                        NumberOfBets = thisRaceHorseBets.Count,
                        TotalBet = thisRaceHorseBets.Sum(x => x.Stake)
                    };

                    horseRace.OwingOnWin = horseRace.TotalBet * horseRace.Horse.Odds;
                    raceDetails.HorseRaces.Add(horseRace);
                }
                result.Add(raceDetails);
            }
            return result;
        }
        
        public IEnumerable<RaceDetail> GetRaceDetailsV1()
        {
            var allBets = _betServices.GetAll();
            var result = GetAll().ToRaceDetails(allBets);

            return result;
        }
    }

}
