using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeslaRent_01.WebApplication.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DailyRateShortTerm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyRateMidTerm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DailyRateLongTerm = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
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
                columns: new[] { "Id", "DailyRateLongTerm", "DailyRateMidTerm", "DailyRateShortTerm", "Name" },
                values: new object[,]
                {
                    { 1, 165m, 200m, 220m, "Tesla Model 3" },
                    { 2, 270m, 315m, 350m, "Tesla Model Y" },
                    { 3, 375m, 450m, 500m, "Tesla Model S" },
                    { 4, 500m, 600m, 650m, "Tesla Model X" },
                    { 5, 525m, 640m, 700m, "Tesla Cybertruck" }
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
                columns: new[] { "Id", "CarModelId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 13, 1 },
                    { 14, 1 },
                    { 15, 1 },
                    { 16, 1 },
                    { 17, 2 },
                    { 18, 2 },
                    { 19, 2 },
                    { 20, 2 },
                    { 21, 2 },
                    { 22, 2 },
                    { 23, 2 },
                    { 24, 2 },
                    { 25, 2 },
                    { 26, 2 },
                    { 27, 3 },
                    { 28, 3 },
                    { 29, 3 },
                    { 30, 3 },
                    { 31, 3 },
                    { 32, 3 },
                    { 33, 4 },
                    { 34, 4 },
                    { 35, 4 },
                    { 36, 4 },
                    { 37, 4 },
                    { 38, 4 },
                    { 39, 5 },
                    { 40, 5 }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "CarId", "Email", "EndDate", "EndLocationId", "FirstName", "LastName", "Price", "StartDate", "StartLocationId" },
                values: new object[,]
                {
                    { 1, 1, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 2, 4, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 3, 7, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 4, 10, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 5, 13, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 6, 16, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 7, 17, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 8, 19, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 9, 21, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 10, 23, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 11, 25, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 12, 27, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 13, 29, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 14, 32, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 15, 33, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 16, 35, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 17, 37, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 18, 38, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 1 },
                    { 19, 2, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 20, 5, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 21, 8, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 22, 11, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 23, 14, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 24, 18, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 25, 20, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 26, 22, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 27, 28, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 28, 30, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 29, 34, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 30, 36, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 31, 40, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 2 },
                    { 32, 3, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 3, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 33, 6, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 3, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 34, 9, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 3, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 35, 24, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 3, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 36, 12, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 3, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 3 },
                    { 37, 15, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 4, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 4 },
                    { 38, 26, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 4, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 4 },
                    { 39, 31, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 4, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 4 },
                    { 40, 39, "Tesla@Rent.com", new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 4, "Tesla", "Rent", 0.0m, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Local), 4 }
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
