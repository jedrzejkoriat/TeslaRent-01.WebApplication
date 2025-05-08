using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using TeslaRent_01.WebApplication.Server.Contracts;
using TeslaRent_01.WebApplication.Server.Data;
using TeslaRent_01.WebApplication.Server.Models;

namespace TeslaRent_01.WebApplication.Server.Services
{
    public class SqlService : ISqlService
    {
        private readonly AppDbContext context;

        public SqlService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<List<CarModelVM>> GetAvailableCarModelVMsAsync(ReservationSearchVM reservationSearchVM)
        {
            var query = @"
                WITH PreviousReservations AS (
                    SELECT r.CarId, r.EndLocationId
                    FROM Reservations r
                    WHERE r.EndDate < @StartDate
                    AND r.Id IN (
                        SELECT TOP 1 r2.Id
                        FROM Reservations r2
                        WHERE r2.CarId = r.CarId
                        AND r2.EndDate < @StartDate
                        ORDER BY r2.EndDate DESC
                    )
                ),
                NextReservations AS (
                    SELECT r.CarId, r.StartLocationId
                    FROM Reservations r
                    WHERE r.StartDate > @EndDate
                    AND r.Id IN (
                        SELECT TOP 1 r2.Id
                        FROM Reservations r2
                        WHERE r2.CarId = r.CarId
                        AND r2.StartDate > @EndDate
                        ORDER BY r2.StartDate ASC
                    )
                ),
                FilteredCars AS (
                    SELECT c.Id AS CarId, c.CarModelId, c.DaysInService
                    FROM Cars c
                    WHERE NOT EXISTS (
                        SELECT 1
                        FROM Reservations r
                        WHERE r.CarId = c.Id
                        AND NOT (r.EndDate < @StartDate OR r.StartDate > @EndDate)
                    )
                ),
                RankedCars AS (
                    SELECT fc.CarId, fc.CarModelId, fc.DaysInService, ROW_NUMBER() OVER (PARTITION BY fc.CarModelId ORDER BY fc.DaysInService ASC) AS rn
                    FROM FilteredCars fc
                    LEFT JOIN PreviousReservations pr ON fc.CarId = pr.CarId
                    LEFT JOIN NextReservations nr ON fc.CarId = nr.CarId
                    WHERE (pr.EndLocationId IS NULL OR pr.EndLocationId = @StartLocationId)
                    AND (nr.StartLocationId IS NULL OR nr.StartLocationId = @EndLocationId)
                )
                SELECT rc.CarModelId, 
                       cm.Name AS CarModelName,
                       CASE
                           WHEN DATEDIFF(DAY, @StartDate, @EndDate) < 7 THEN DATEDIFF(DAY, @StartDate, @EndDate) * cm.DailyRateShortTerm
                           WHEN DATEDIFF(DAY, @StartDate, @EndDate) BETWEEN 7 AND 29 THEN DATEDIFF(DAY, @StartDate, @EndDate) * cm.DailyRateMidTerm
                           ELSE DATEDIFF(DAY, @StartDate, @EndDate) * cm.DailyRateLongTerm
                       END AS Price
                FROM RankedCars rc
                JOIN CarModels cm ON rc.CarModelId = cm.Id
                WHERE rc.rn = 1;
            ";

            var startDateParam = new SqlParameter("@StartDate", SqlDbType.DateTime) { Value = reservationSearchVM.StartDate };
            var endDateParam = new SqlParameter("@EndDate", SqlDbType.DateTime) { Value = reservationSearchVM.EndDate };
            var startLocationParam = new SqlParameter("@StartLocationId", SqlDbType.Int) { Value = reservationSearchVM.StartLocationId };
            var endLocationParam = new SqlParameter("@EndLocationId", SqlDbType.Int) { Value = reservationSearchVM.EndLocationId };

            var result = await context.Set<CarModelVM>()
                .FromSqlRaw(query, startDateParam, endDateParam, startLocationParam, endLocationParam)
                .ToListAsync();

            return result;
        }

        public async Task<int?> GetAvailableCarIdAsync(ReservationCreateVM reservationCreateVM)
        {
            var query = @"
                WITH PreviousReservations AS (
                    SELECT r.CarId, r.EndLocationId
                    FROM Reservations r
                    WHERE r.EndDate < @StartDate
                    AND r.Id IN (
                        SELECT TOP 1 r2.Id
                        FROM Reservations r2
                        WHERE r2.CarId = r.CarId
                        AND r2.EndDate < @StartDate
                        ORDER BY r2.EndDate DESC
                    )
                ),
                NextReservations AS (
                    SELECT r.CarId, r.StartLocationId
                    FROM Reservations r
                    WHERE r.StartDate > @EndDate
                    AND r.Id IN (
                        SELECT TOP 1 r2.Id
                        FROM Reservations r2
                        WHERE r2.CarId = r.CarId
                        AND r2.StartDate > @EndDate
                        ORDER BY r2.StartDate ASC
                    )
                ),
                FilteredCars AS (
                    SELECT c.Id AS CarId, c.CarModelId, c.DaysInService
                    FROM Cars c
                    WHERE c.CarModelId = @CarModelId
                    AND NOT EXISTS (
                        SELECT 1
                        FROM Reservations r
                        WHERE r.CarId = c.Id
                        AND NOT (r.EndDate < @StartDate OR r.StartDate > @EndDate)
                    )
                ),
                RankedCars AS (
                    SELECT fc.CarId, ROW_NUMBER() OVER (ORDER BY fc.DaysInService ASC) AS rn
                    FROM FilteredCars fc
                    LEFT JOIN PreviousReservations pr ON fc.CarId = pr.CarId
                    LEFT JOIN NextReservations nr ON fc.CarId = nr.CarId
                    WHERE (pr.EndLocationId IS NULL OR pr.EndLocationId = @StartLocationId)
                    AND (nr.StartLocationId IS NULL OR nr.StartLocationId = @EndLocationId)
                )
                SELECT rc.CarId
                FROM RankedCars rc
                WHERE rc.rn = 1;
            ";

            var startDateParam = new SqlParameter("@StartDate", SqlDbType.DateTime) { Value = reservationCreateVM.StartDate };
            var endDateParam = new SqlParameter("@EndDate", SqlDbType.DateTime) { Value = reservationCreateVM.EndDate };
            var startLocationParam = new SqlParameter("@StartLocationId", SqlDbType.Int) { Value = reservationCreateVM.StartLocationId };
            var endLocationParam = new SqlParameter("@EndLocationId", SqlDbType.Int) { Value = reservationCreateVM.EndLocationId };
            var carModelIdParam = new SqlParameter("@CarModelId", SqlDbType.Int) { Value = reservationCreateVM.CarModelId };

            var result = await context.Set<CarVM>()
                .FromSqlRaw(query, startDateParam, endDateParam, startLocationParam, endLocationParam, carModelIdParam)
                .ToListAsync();

            return result.FirstOrDefault()?.Id;
        }
    }
}
