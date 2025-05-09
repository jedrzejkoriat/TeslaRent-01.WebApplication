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

        public TeslaRentService(
            IReservationRepository reservationRepository,
            ILocationRepository locationRepository,
            ISqlService sqlService,
            IMapper mapper,
            IEmailSender emailSender)
        {
            this.reservationRepository = reservationRepository;
            this.locationRepository = locationRepository;
            this.sqlService = sqlService;
            this.mapper = mapper;
            this.emailSender = emailSender;
        }

        // Gets all available locations
        public async Task<List<LocationVM>> GetAvailableLocationVMsAsync()
        {
            return mapper.Map<List<LocationVM>>(await locationRepository.GetAllAsync());
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
            else
            {
                Reservation reservation = mapper.Map<Reservation>(reservationCreateVM);
                reservation.CarId = carId.Value;

                string emailSubject = "TeslaRent reservation confirmation";
                string emailBody = $"Your reservation for Tesla Model";

                try
                {
                    await emailSender.SendEmailAsync(reservation.Email, emailSubject, emailBody);
                    await reservationRepository.AddAsync(reservation);
                }
                catch(Exception ex)
                {
                    throw new Exception("Error while creating reservation:" + ex.Message);
                }
            }
        }

    }
}
