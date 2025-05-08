using TeslaRent_01.WebApplication.Server.Contracts;
using TeslaRent_01.WebApplication.Server.Data;
using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Services
{
    public class TeslaReservationService : ITeslaReservationService
    {
        private readonly ICarRepository carRepository;
        private readonly ICarModelRepository carModelRepository;
        private readonly IReservationRepository reservationRepository;
        private readonly ILocationRepository locationRepository;
        private readonly ISqlService sqlService;

        public TeslaReservationService(
            ICarRepository carRepository, 
            ICarModelRepository carModelRepository,
            IReservationRepository reservationRepository,
            ILocationRepository locationRepository,
            ISqlService sqlService)
        {
            this.carRepository = carRepository;
            this.carModelRepository = carModelRepository;
            this.reservationRepository = reservationRepository;
            this.locationRepository = locationRepository;
            this.sqlService = sqlService;
        }

        public async Task<List<AvailableCarsVM>> GetAvailableCarsVMAsync(ReservationSearchVM reservationSearchVM)
        {
            return await sqlService.GetAvailableCarsVMAsync(reservationSearchVM);
        }

    }
}
