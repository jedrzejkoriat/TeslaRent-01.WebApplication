using TeslaRent_01.WebApplication.Server.Contracts;
using TeslaRent_01.WebApplication.Server.Data;

namespace TeslaRent_01.WebApplication.Server.Repositories;

internal sealed class CarModelRepository : GenericRepository<CarModel>, ICarModelRepository
{
    public CarModelRepository(AppDbContext context) : base(context)
    {

    }
}
