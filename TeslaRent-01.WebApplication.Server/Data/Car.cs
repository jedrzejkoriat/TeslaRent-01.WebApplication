namespace TeslaRent_01.WebApplication.Server.Data
{
    public class Car
    {
        // ID
        public int Id { get; set; }
        // RELATIONS
        public int ModelId { get; set; }
        public Model Model { get; set; }
    }
}
