namespace TeslaRent_01.WebApplication.Server.ViewModels
{
    public class ReservationCreateVM : ReservationSearchVM
    {
        public int ModelId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
