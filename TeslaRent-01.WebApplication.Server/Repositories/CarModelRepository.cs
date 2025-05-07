using TeslaRent_01.WebApplication.Server.Contracts;
using TeslaRent_01.WebApplication.Server.Data;

namespace TeslaRent_01.WebApplication.Server.Repositories
{
    public class CarModelRepository : GenericRepository<CarModel>, IGenericRepository<CarModel>
    {
        public CarModelRepository(AppDbContext context) : base(context)
        {
        }
    }
}
