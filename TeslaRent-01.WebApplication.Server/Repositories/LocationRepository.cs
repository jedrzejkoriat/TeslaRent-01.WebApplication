using TeslaRent_01.WebApplication.Server.Contracts;
using TeslaRent_01.WebApplication.Server.Data;

namespace TeslaRent_01.WebApplication.Server.Repositories
{
    public sealed class LocationRepository : GenericRepository<Location>
    {
        public LocationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
