using System.Collections.Generic;
using System.Linq;
using LetsBet.BusinessServices;
using LetsBet.BusinessServices.ModelViews;
using LetsBet.Models;
using Microsoft.AspNetCore.Mvc;

namespace LetsBet.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class RacesController : Controller
    {
        private IRaceBusinessServices _raceBusinessServices;
        public RacesController(
            IRaceBusinessServices raceBusinessServices)
        {
            _raceBusinessServices = raceBusinessServices;
        }
        [HttpGet]
        public IEnumerable<Race> GetRaces()
        {
            var result = _raceBusinessServices.GetAll();
            return result;
        }
        [Route("details")]
        public List<RaceBetViewModel> GetRaceDetails()
        {
            var result = _raceBusinessServices.GetRaceDetails().Select(x => x.ToViewModel()).ToList();
            return result;
        }

        [Route("v1/details")]
        public List<RaceBetViewModel> GetRaceDetails_V1()
        {
            var result = _raceBusinessServices.GetRaceDetailsV1().Select(x => x.ToViewModel()).ToList();
            return result;
        }
    }
}