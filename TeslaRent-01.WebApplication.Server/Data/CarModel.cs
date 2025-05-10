namespace TeslaRent_01.WebApplication.Server.Data
{
    public sealed record class CarModel
    {
        // IDs
        public int Id { get; init; }
        // STRINGS
        public string Name { get; init; }
        // NUMBERS
        public decimal DailyRateShortTerm { get; init; }
        public decimal DailyRateMidTerm { get; init; }
        public decimal DailyRateLongTerm { get; init; }
    }
}
