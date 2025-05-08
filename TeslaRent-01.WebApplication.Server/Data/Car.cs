namespace TeslaRent_01.WebApplication.Server.Data
{
    public class Car
    {
        // ID
        public int Id { get; set; }
        public int DaysInService { get; set; }
        // RELATIONS
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }
    }
}
