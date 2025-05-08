using AutoMapper;
using TeslaRent_01.WebApplication.Server.Data;
using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<ReservationCreateVM, Reservation>();
            CreateMap<Location, LocationVM>();
            CreateMap<ReservationCreateVM, ReservationSearchVM>();
        }
    }
}
