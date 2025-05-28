using AutoMapper;
using TeslaRent_01.WebApplication.Server.Data;
using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Configuration
{
    internal sealed class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ReservationCreateVM, Reservation>();
            CreateMap<Location, LocationNameVM>();
            CreateMap<Location, LocationDetailsVM>();
            CreateMap<ReservationCreateVM, ReservationSearchVM>();
            CreateMap<CarModel, OurCarVM>();
        }
    }
}
