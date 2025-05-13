using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeslaRent_01.WebApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDescriptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvailableCarModelVMs",
                columns: table => new
                {
                    CarModelId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BodyType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DailyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    MaxSpeed = table.Column<int>(type: "int", nullable: false),
                    MaxRange = table.Column<int>(type: "int", nullable: false),
                    Acceleration = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "AvailableCarVMs",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BodyType = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DailyRateShortTerm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyRateMidTerm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyRateLongTerm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    MaxSpeed = table.Column<int>(type: "int", nullable: false),
                    MaxRange = table.Column<int>(type: "int", nullable: false),
                    Acceleration = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    StreetNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DaysInService = table.Column<int>(type: "int", nullable: false),
                    CarModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarModels_CarModelId",
                        column: x => x.CarModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    StartLocationId = table.Column<int>(type: "int", nullable: false),
                    EndLocationId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Locations_EndLocationId",
                        column: x => x.EndLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Locations_StartLocationId",
                        column: x => x.StartLocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "Acceleration", "BodyType", "DailyRateLongTerm", "DailyRateMidTerm", "DailyRateShortTerm", "Description", "MaxRange", "MaxSpeed", "Name", "Seats" },
                values: new object[,]
                {
                    { 1, 3.1m, "Sedan", 165m, 200m, 220m, "A compact electric sedan offering high performance and range. With its sleek design and incredible efficiency, the Model 3 is perfect for city driving and long road trips. Ideal for families looking for an efficient yet fun ride.", 491, 261, "Tesla Model 3", 5 },
                    { 2, 5.0m, "SUV", 270m, 315m, 350m, "A spacious electric SUV with advanced features and great range. With ample space for both passengers and cargo, the Model Y combines practicality with high-tech performance. Perfect for families or adventurous trips with friends.", 499, 217, "Tesla Model Y", 5 },
                    { 3, 2.1m, "Sedan", 375m, 450m, 500m, "A luxury electric sedan with impressive range and acceleration. The Model S offers a blend of unmatched performance, sleek design, and top-tier technology. Ideal for those who seek a luxurious, high-performance ride.", 652, 322, "Tesla Model S", 5 },
                    { 4, 2.6m, "SUV", 500m, 600m, 650m, "A premium electric SUV with falcon-wing doors and roomy interior. Offering a spacious cabin and cutting-edge technology, the Model X is ready for any family adventure. Perfect for large families or those who need extra space and style.", 543, 262, "Tesla Model X", 7 },
                    { 5, 3.0m, "Pickup", 525m, 640m, 700m, "A futuristic electric pickup truck built for durability and power. With its tough exterior and impressive capabilities, the Cybertruck is designed to handle heavy-duty tasks with ease. Ideal for those who need a powerful and reliable vehicle for work or family use.", 750, 210, "Tesla Cybertruck", 6 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "Country", "Name", "Street", "StreetNumber", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Palma", "Spain", "Palma Airport", "Carrer del Camp Franc", "2", "07199" },
                    { 2, "Palma", "Spain", "Palma City Center", "Carrer del 31 de Desembre", "3", "07003" },
                    { 3, "Alcudia", "Spain", "Alcudia", "Av. Pere Mas i Reus", "36A", "07410" },
                    { 4, "Manacor", "Spain", "Manacor", "Carrer del Pintor Joan Gris", "13", "07500" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CarModelId", "DaysInService" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 1, 0 },
                    { 3, 1, 0 },
                    { 4, 1, 0 },
                    { 5, 1, 0 },
                    { 6, 1, 0 },
                    { 7, 1, 0 },
                    { 8, 1, 0 },
                    { 9, 1, 0 },
                    { 10, 1, 0 },
                    { 11, 1, 0 },
                    { 12, 1, 0 },
                    { 13, 1, 0 },
                    { 14, 1, 0 },
                    { 15, 1, 0 },
                    { 16, 1, 0 },
                    { 17, 2, 0 },
                    { 18, 2, 0 },
                    { 19, 2, 0 },
                    { 20, 2, 0 },
                    { 21, 2, 0 },
                    { 22, 2, 0 },
                    { 23, 2, 0 },
                    { 24, 2, 0 },
                    { 25, 2, 0 },
                    { 26, 2, 0 },
                    { 27, 3, 0 },
                    { 28, 3, 0 },
                    { 29, 3, 0 },
                    { 30, 3, 0 },
                    { 31, 3, 0 },
                    { 32, 3, 0 },
                    { 33, 4, 0 },
                    { 34, 4, 0 },
                    { 35, 4, 0 },
                    { 36, 4, 0 },
                    { 37, 4, 0 },
                    { 38, 4, 0 },
                    { 39, 5, 0 },
                    { 40, 5, 0 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CarId", "Email", "EndDate", "EndLocationId", "FirstName", "LastName", "PhoneNumber", "Price", "StartDate", "StartLocationId" },
                values: new object[,]
                {
                    { 1, 1, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 2, 4, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 3, 7, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 4, 10, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 5, 13, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 6, 16, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 7, 17, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 8, 19, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 9, 21, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 10, 23, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 11, 25, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 12, 27, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 13, 29, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 14, 32, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 15, 33, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 16, 37, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 17, 38, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 18, 39, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 19, 2, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 20, 5, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 21, 8, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 22, 11, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 23, 14, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 24, 18, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 25, 20, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 26, 22, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 27, 28, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 28, 30, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 29, 34, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 30, 36, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 31, 40, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 32, 3, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 3, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 33, 6, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 3, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 34, 9, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 3, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 35, 24, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 3, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 36, 12, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 3, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 37, 15, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 4, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 4 },
                    { 38, 26, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 4, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 4 },
                    { 39, 31, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 4, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 4 },
                    { 40, 35, "Tesla@Rent.com", new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 4, "Tesla", "Rent", "+48123456789", 0.0m, new DateTime(2025, 5, 12, 0, 0, 0, 0, DateTimeKind.Local), 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CarModelId",
                table: "Cars",
                column: "CarModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CarId",
                table: "Reservations",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_EndLocationId",
                table: "Reservations",
                column: "EndLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_StartLocationId",
                table: "Reservations",
                column: "StartLocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvailableCarModelVMs");

            migrationBuilder.DropTable(
                name: "AvailableCarVMs");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "CarModels");
        }
    }
}
