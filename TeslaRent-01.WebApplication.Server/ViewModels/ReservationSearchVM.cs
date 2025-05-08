namespace TeslaRent_01.WebApplication.Server.ViewModels
{
    public class ReservationSearchVM
    {
        public int StartLocationId { get; set; }
        public int EndLocationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
