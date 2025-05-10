namespace TeslaRent_01.WebApplication.Server.Data
{
    public sealed record class Location
    {
        // IDs
        public int Id { get; init; }
        // STRINGS
        public string Name { get; init; }
        public string Country { get; init; }
        public string City { get; init; }
        public string ZipCode { get; init; }
        public string Street { get; init; }
        public string StreetNumber { get; init; }
    }
}
