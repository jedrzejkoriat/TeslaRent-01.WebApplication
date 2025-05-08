# TeslaRent-01.WebApplication

Project assumptions (09.05.2025):
```
1. Locations: 
    Palma Airport
    Palma City Center
    Alcudia
    Manacor

2.  Cars (daily price -7days, 7-30days, 30+days) 
    Tesla Model 3 (220, 200, 165) - 16szt
    Tesla Model Y (350, 315, 270) - 10szt
    Tesla Model S (500, 450, 375) - 6szt
    Tesla Model X (650, 600, 500) - 6szt
    Tesla Cybertruck (700, 640, 525) - 2szt

3.  Tables
    Reservations (Id, CarId, StartLocationId, StartDate, EndLocationId, EndDate, Price, Email, FirstName, LastName)
    Cars (Id, CarModelId)
    CarModels (Id, Name, DailyRateShortTerm, DailyRateMidTerm, DailyRateLongTerm)
    Locations (Id, Name, Country, City, Postcode, Street, StreetNumber)

4.  Views:
    ReservationSearchVM form (startDate, endDate, startLocation, endLocation)
    AvailableCarsVM list (modelId, NumberOfCarModelAvailable, Name, TotalPrice)[]
    ReservationCreateVM (firstName, lastName, email, price, modelId)
	Approval (+ send email) / decline (+ showerror)

5.  Endpoints
    GET app.MapGet("/api/reservations/start/{startLocationId}/{startDate}/end/{endLocationId}/{endDate}" - RESPONSE {string CarModel.Name, int CarId, dec Price}[]
    POST app.MapPost("/api/reservations") - body {JSON} - {int CarId, int StartLocationId, int EndLocationId, DateTime StartDate, DateTime EndDate, string FirstName, string LastName, string Email, decimal Price} - RESPONSE { ok, problem }
```
