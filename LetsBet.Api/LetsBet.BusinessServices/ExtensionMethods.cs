using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LetsBet.BusinessServices.ModelViews;
using LetsBet.Models;

namespace LetsBet.BusinessServices
{
    public static class ExtensionMethods
    {
        public static IEnumerable<RaceDetail> ToRaceDetails(this IEnumerable<Race> races) => races?.Select(race => new RaceDetail(race, new List<Bet>()));

        public static RaceBetViewModel ToViewModel(this RaceBets racebet)
        {
            return (racebet == null) ? null
                : new RaceBetViewModel
                {
                    Id = racebet.Id,
                    Name = racebet.Name,
                    Status = racebet.Status,
                    RaceTotalBet = racebet.RaceTotalBet,
                    HorseRace = racebet.HorseRaces.Select(x => new HorseRaceViewModel { HorseId = x.Horse.Id, HorseName = x.Horse.Name, RaceId = x.RaceId, NumberOfBets = x.NumberOfBets, TotalBet = x.TotalBet, OwingOnWin = x.OwingOnWin }).ToList()
                };
        }

        public static RaceBetViewModel ToViewModel(this RaceDetail raceDetail)
        {
            return (raceDetail == null) ? null
                : new RaceBetViewModel
                {
                    Id = raceDetail.Race.Id,
                    Name = raceDetail.Race.Name,
                    Status = raceDetail.Race.Status,
                    RaceTotalBet = raceDetail.RaceTotalBet,
                    HorseRace = raceDetail.HorseRaces.Select(x => new HorseRaceViewModel { HorseId = x.Horse.Id, HorseName = x.Horse.Name, RaceId = x.RaceId, NumberOfBets = x.NumberOfBets, TotalBet = x.TotalBet, OwingOnWin = x.OwingOnWin }).ToList()
                };
        }
        public static IEnumerable<RaceDetail> ToRaceDetails(this IEnumerable<Race> races, IEnumerable<Bet> bets)
        {

            foreach (var race in races)
            {
                if (bets == null) yield break;
                var raceBets = bets.Where(x => x.RaceId == race.Id);
                var newRaceDetail = new RaceDetail(race, raceBets)
                {
                    HorseRaces = race.Horses.Select(x =>
                    {
                        var raceBetsOnHorse = raceBets.Where(y => y.HorseId == x.Id).ToList();
                        var horseRace = new HorseRace
                        {
                            Horse = x,
                            RaceId = race.Id,
                            NumberOfBets = raceBetsOnHorse.Count,
                            TotalBet = raceBetsOnHorse.Sum(i => i.Stake)
                        };
                        horseRace.OwingOnWin = horseRace.TotalBet * x.Odds;
                        return horseRace;
                    })
                };
                yield return newRaceDetail;
            }
        }
    }
}
