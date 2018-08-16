
namespace LetsBet.Models
{
    public class HorseRace
    {
        public Horse Horse { get; set; }
        public int RaceId { get; set; }
        public int NumberOfBets { get; set; }
        public decimal TotalBet { get; set; }
        public decimal OwingOnWin { get; set; }
    }
}
