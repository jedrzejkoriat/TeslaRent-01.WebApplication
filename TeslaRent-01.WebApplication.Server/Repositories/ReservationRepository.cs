using TeslaRent_01.WebApplication.Server.Contracts;
using TeslaRent_01.WebApplication.Server.Data;

namespace TeslaRent_01.WebApplication.Server.Repositories
{
    public sealed class ReservationRepository : GenericRepository<Reservation>
    {
        public ReservationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
