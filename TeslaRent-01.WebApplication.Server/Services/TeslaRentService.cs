using AutoMapper;
using Microsoft.AspNetCore.Identity.UI.Services;
using PdfSharp.Pdf;
using TeslaRent_01.WebApplication.Server.Contracts;
using TeslaRent_01.WebApplication.Server.Data;
using TeslaRent_01.WebApplication.Server.Models;
using TeslaRent_01.WebApplication.Server.Repositories;

namespace TeslaRent_01.WebApplication.Server.Services
{
    public class TeslaRentService : ITeslaRentService
    {
        private readonly IReservationRepository reservationRepository;
        private readonly ILocationRepository locationRepository;
        private readonly ICarRepository carRepository;
        private readonly ISqlService sqlService;
        private readonly IMapper mapper;
        private readonly IEmailSender emailSender;
        private readonly IEmailBuilder emailBuilder;
        private readonly IPdfBuilder pdfBuilder;

        public TeslaRentService(
            IReservationRepository reservationRepository,
            ILocationRepository locationRepository,
            ICarRepository carRepository,
            ISqlService sqlService,
            IMapper mapper,
            IEmailSender emailSender,
            IEmailBuilder emailBuilder,
            IPdfBuilder pdfBuilder)
        {
            this.reservationRepository = reservationRepository;
            this.locationRepository = locationRepository;
            this.carRepository = carRepository;
            this.sqlService = sqlService;
            this.mapper = mapper;
            this.emailSender = emailSender;
            this.emailBuilder = emailBuilder;
            this.pdfBuilder = pdfBuilder;
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
        public async Task<MemoryStream> CreateReservationAsync(ReservationCreateVM reservationCreateVM)
        {
            // Search for available car ID based on the reservation criteria - this is to prevent a situation where two users view the same car model and try to reserve it at the same time
            int? carId = await sqlService.GetAvailableCarIdAsync(reservationCreateVM);

            if (carId == null)
            {
                throw new InvalidOperationException("No available car found for the specified criteria.");
            }

            // Create reservation object and add carId value to it
            Reservation reservation = mapper.Map<Reservation>(reservationCreateVM);
            reservation.CarId = carId.Value;
            await reservationRepository.AddAsync(reservation);

            // Update the car's days in service
            int reservationLength = (int)(reservation.EndDate - reservation.StartDate).TotalDays;
            await carRepository.AddDaysToCarAsync(carId.Value, reservationLength);

            // Build ReservationDetailsVM object for pdf and email
            LocationDetailsVM startLocationVM = mapper.Map<LocationDetailsVM>(await locationRepository.GetAsync(reservation.StartLocationId));
            LocationDetailsVM endLocationVM = mapper.Map<LocationDetailsVM>(await locationRepository.GetAsync(reservation.EndLocationId));

            ReservationDetailsVM reservationDetailsVM = new ReservationDetailsVM
            {
                ReservationCreateVM = reservationCreateVM,
                StartLocationVM = startLocationVM,
                EndLocationVM = endLocationVM
            };

            // Build and send reservation email
            (string emailSubject, string emailBody) = emailBuilder.BuildReservationEmail(reservationDetailsVM);
            await emailSender.SendEmailAsync(reservation.Email, emailSubject, emailBody);

            // Build and return pdf
            MemoryStream reservationDocument = pdfBuilder.BuildReservationPdf(reservationDetailsVM);
            return reservationDocument;
        }

    }
}
