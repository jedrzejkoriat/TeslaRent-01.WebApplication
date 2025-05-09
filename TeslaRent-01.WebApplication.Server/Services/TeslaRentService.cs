using AutoMapper;
using Microsoft.AspNetCore.Identity.UI.Services;
using TeslaRent_01.WebApplication.Server.Contracts;
using TeslaRent_01.WebApplication.Server.Data;
using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Services
{
    public class TeslaRentService : ITeslaRentService
    {
        private readonly IReservationRepository reservationRepository;
        private readonly ILocationRepository locationRepository;
        private readonly ISqlService sqlService;
        private readonly IMapper mapper;
        private readonly IEmailSender emailSender;
        private readonly ICarModelRepository carModelRepository;
        private readonly IEmailBuilder emailBuilder;

        public TeslaRentService(
            IReservationRepository reservationRepository,
            ILocationRepository locationRepository,
            ISqlService sqlService,
            IMapper mapper,
            IEmailSender emailSender,
            ICarModelRepository carModelRepository,
            IEmailBuilder emailBuilder)
        {
            this.reservationRepository = reservationRepository;
            this.locationRepository = locationRepository;
            this.sqlService = sqlService;
            this.mapper = mapper;
            this.emailSender = emailSender;
            this.carModelRepository = carModelRepository;
            this.emailBuilder = emailBuilder;
        }

        // Gets all available locations
        public async Task<List<LocationNameVM>> GetAvailableLocationVMsAsync()
        {
            return mapper.Map<List<LocationNameVM>>(await locationRepository.GetAllAsync());
        }

        // Gets all available car models for the given dates and locations
        public async Task<List<CarModelVM>> GetAvailableCarVMsAsync(ReservationSearchVM reservationSearchVM)
        {
            return await sqlService.GetAvailableCarModelVMsAsync(reservationSearchVM);
        }

        // Creates a reservation for the selected car model
        public async Task CreateReservationAsync(ReservationCreateVM reservationCreateVM)
        {
            // Search for available car ID based on the reservation criteria - this is to prevent a situation where two users view the same car model and try to reserve it at the same time
            int? carId = await sqlService.GetAvailableCarIdAsync(reservationCreateVM);

            if (carId == null)
            {
                throw new InvalidOperationException("No available car found for the specified criteria.");
            }

            Reservation reservation = mapper.Map<Reservation>(reservationCreateVM);
            reservation.CarId = carId.Value;
            await reservationRepository.AddAsync(reservation);

            LocationDetailsVM startLocationVM = mapper.Map<LocationDetailsVM>(await locationRepository.GetAsync(reservation.StartLocationId));
            LocationDetailsVM endLocationVM = mapper.Map<LocationDetailsVM>(await locationRepository.GetAsync(reservation.EndLocationId));
            string carModelName = (await carModelRepository.GetAsync(carId.Value)).Name;

            ReservationDetailsVM reservationDetailsVM = new ReservationDetailsVM
            {
                ReservationCreateVM = reservationCreateVM,
                StartLocationVM = startLocationVM,
                EndLocationVM = endLocationVM,
                CarModelName = carModelName
            };

            (string emailSubject, string emailBody) = emailBuilder.BuildReservationEmail(reservationDetailsVM);

            await emailSender.SendEmailAsync(reservation.Email, emailSubject, emailBody);
        }

    }
}
