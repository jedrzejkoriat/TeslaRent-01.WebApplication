namespace TeslaRent_01.WebApplication.Server.Data
{
    public sealed record class Reservation
    {
        // ID
        public int? Id { get; init; }
        // RELATIONS
        public int CarId { get; set; }
        public Car Car { get; init; }
        public int StartLocationId { get; init; }
        public Location StartLocation { get; init; }
        public int EndLocationId { get; init; }
        public Location EndLocation { get; init; }
        // DATES
        public DateTime StartDate { get; init; }
        public DateTime EndDate { get; init; }
        // STRINGS
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        // NUMBERS
        public decimal Price { get; init; }
    }
}
