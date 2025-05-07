namespace TeslaRent_01.WebApplication.Server.Data
{
    public class Location
    {
        // IDs
        public int Id { get; set; }
        // STRINGS
        public string Name { get; set; }
        // ADDRESS
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
    }
}
