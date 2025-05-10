namespace TeslaRent_01.WebApplication.Server.Models
{
    public record LocationDetailsVM
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Street { get; set; }
        public string StreetNumber { get; set; }
    }
}
