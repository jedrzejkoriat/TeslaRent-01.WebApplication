namespace TeslaRent_01.WebApplication.Server.Data
{
    public class CarModel
    {
        // IDs
        public int Id { get; set; }
        // STRINGS
        public string Name { get; set; }
        // PRICING
        public decimal DailyRateShortTerm { get; set; }
        public decimal DailyRateMidTerm { get; set; }
        public decimal DailyRateLongTerm { get; set; }
    }
}
