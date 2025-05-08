using TeslaRent_01.WebApplication.Server.Contracts;
using TeslaRent_01.WebApplication.Server.Data;

namespace TeslaRent_01.WebApplication.Server.Services
{
    public class TeslaReservationService : ITeslaReservationService
    {
        private readonly ICarRepository carRepository;
        private readonly ICarModelRepository carModelRepository;
        private readonly IReservationRepository reservationRepository;
        private readonly ILocationRepository locationRepository;

        public TeslaReservationService(
            ICarRepository carRepository, 
            ICarModelRepository carModelRepository,
            IReservationRepository reservationRepository,
            ILocationRepository locationRepository)
        {
            this.carRepository = carRepository;
            this.carModelRepository = carModelRepository;
            this.reservationRepository = reservationRepository;
            this.locationRepository = locationRepository;
        }



    }
}
