using TeslaRent_01.WebApplication.Server.Contracts;
using TeslaRent_01.WebApplication.Server.Data;

namespace TeslaRent_01.WebApplication.Server.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IGenericRepository<Reservation>
    {
        public ReservationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
