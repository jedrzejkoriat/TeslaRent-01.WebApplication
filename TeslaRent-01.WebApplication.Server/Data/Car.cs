namespace TeslaRent_01.WebApplication.Server.Data
{
    public sealed record class Car
    {
        // ID
        public int Id { get; init; }
        public int DaysInService { get; set; }
        // RELATIONS
        public int CarModelId { get; init; }
        public CarModel CarModel { get; init; }
    }
}
