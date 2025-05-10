using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TeslaRent_01.WebApplication.Server.Data;

namespace TeslaRent_01.WebApplication.Server.Configuration.Entities
{
    internal sealed class LocationSeedConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasData(
                new Location { Id = 1, Country = "Spain", Name = "Palma Airport", City = "Palma", Street = "Carrer del Camp Franc", StreetNumber = "2", ZipCode = "07199"},
                new Location { Id = 2, Country = "Spain", Name = "Palma City Center", City = "Palma", Street = "Carrer del 31 de Desembre", StreetNumber = "3", ZipCode = "07003" },
                new Location { Id = 3, Country = "Spain", Name = "Alcudia", City = "Alcudia", Street = "Av. Pere Mas i Reus", StreetNumber = "36A", ZipCode = "07410" },
                new Location { Id = 4, Country = "Spain", Name = "Manacor", City = "Manacor", Street = "Carrer del Pintor Joan Gris", StreetNumber = "13", ZipCode = "07500" }
                );
        }
    }
}
