namespace TeslaRent_01.WebApplication.Server.Data
{
    public class Reservation
    {
        // ID
        public int? Id { get; set; }
        // RELATIONS
        public int CarId { get; set; }
        public Car Car { get; set; }
        public int StartLocationId { get; set; }
        public Location StartLocation { get; set; }
        public int EndLocationId { get; set; }
        public Location EndLocation { get; set; }
        // DATES
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        // STRINGS
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        // NUMBERS
        public decimal Price { get; set; }
    }
}
