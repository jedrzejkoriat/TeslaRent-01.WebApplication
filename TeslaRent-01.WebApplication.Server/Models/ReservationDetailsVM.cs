namespace TeslaRent_01.WebApplication.Server.Models
{
    public sealed record ReservationDetailsVM
    {
        public LocationDetailsVM StartLocationVM { get; set; }
        public LocationDetailsVM EndLocationVM { get; set; }
        public ReservationCreateVM ReservationCreateVM { get; set; }
    }
}
