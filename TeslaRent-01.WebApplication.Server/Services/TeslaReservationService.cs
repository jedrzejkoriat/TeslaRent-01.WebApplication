using TeslaRent_01.WebApplication.Server.Contracts;
using TeslaRent_01.WebApplication.Server.Data;

namespace TeslaRent_01.WebApplication.Server.Services
{
    public class TeslaReservationService : ITeslaReservationService
    {
        private readonly AppDbContext context;

        public TeslaReservationService(AppDbContext context)
        {
            this.context = context;
        }
    }
}
