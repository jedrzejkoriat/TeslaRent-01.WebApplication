namespace TeslaRent_01.WebApplication.Server.ViewModels
{
    public class AvailableCarsVM
    {
        public int ModelId { get; set; }
        public int NumberOfCarModelAvailable { get; set; }
        public string Name { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
