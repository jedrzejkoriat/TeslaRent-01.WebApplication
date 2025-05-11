namespace TeslaRent_01.WebApplication.Server.Data
{
    public sealed record class CarModel
    {
        // IDs
        public int Id { get; init; }
        // STRINGS
        public string Name { get; init; }
        public string BodyType { get; init; }
        public string Description { get; init; }
        // NUMBERS
        public decimal DailyRateShortTerm { get; init; }
        public decimal DailyRateMidTerm { get; init; }
        public decimal DailyRateLongTerm { get; init; }
        public int Seats { get; init; }
        public int MaxSpeed { get; init; }
        public int MaxRange { get; init; }
        public decimal Acceleration { get; init; }
    }
}
