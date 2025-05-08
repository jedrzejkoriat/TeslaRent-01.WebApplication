using AutoMapper;
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
        private readonly IMapper mapper;

        public TeslaReservationService(
            ICarRepository carRepository, 
            ICarModelRepository carModelRepository,
            IReservationRepository reservationRepository,
            ILocationRepository locationRepository,
            ISqlService sqlService,
            IMapper mapper)
        {
            this.carRepository = carRepository;
            this.carModelRepository = carModelRepository;
            this.reservationRepository = reservationRepository;
            this.locationRepository = locationRepository;
            this.sqlService = sqlService;
            this.mapper = mapper;
        }

        public async Task<List<LocationVM>> GetAvailableLocationVMsAsync()
        {
            return mapper.Map<List<LocationVM>>(await locationRepository.GetAllAsync());
        }

        public async Task<List<CarModelVM>> GetAvailableCarVMsAsync(ReservationSearchVM reservationSearchVM)
        {
            return await sqlService.GetAvailableCarModelVMsAsync(reservationSearchVM);
        }

        public async Task CreateReservationAsync(ReservationCreateVM reservationCreateVM)
        {
            int? carId = await sqlService.GetAvailableCarIdAsync(reservationCreateVM);
            if (carId == null)
            {
                throw new InvalidOperationException("No available car found for the specified criteria.");
            }
            else
            {
                Reservation reservation = mapper.Map<Reservation>(reservationCreateVM);
                reservation.CarId = carId.Value;
                await reservationRepository.AddAsync(reservation);
            }
        }

    }
}
