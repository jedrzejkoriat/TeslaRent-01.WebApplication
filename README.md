# TeslaRent-01.WebApplication

Aktualne załozenia projektowe (08.05.2025):
```
1. Lokacje: 
    Palma Airport
    Palma City Center
    Alcudia
    Manacor

2. Samochody (cena dzienna -7dni, 7-30dni, 30+dni) 
    Tesla Model 3 (220, 200, 165) - 16szt
    Tesla Model Y (350, 315, 270) - 10szt
    Tesla Model S (500, 450, 375) - 6szt
    Tesla Model X (650, 600, 500) - 6szt
    Tesla Cybertruck (700, 640, 525) - 2szt

3. Tabele:
    Reservations (Id, CarId, StartLocationId, StartDate, EndLocationId, EndDate, Price, Email, FirstName, LastName)
    Cars (Id, CarModelId)
    CarModels (Id, Name, DailyRateShortTerm, DailyRateMidTerm, DailyRateLongTerm)
    Locations (Id, Name, Country, City, Postcode, Street, StreetNumber)

 4. Widoki:
    Formularz (startDate, endDate, startLocation, endLocation)
    Lista przefiltrowanych samochodow (samochody ktore nie maja rezerwacji zazebiajacych sie i maja endlocation w wybranej startLocation)
    Formularz (firstName, lastName, email)
    Potwierdzenie/blad + guzik powrot do formularza

5. Endpointy:
    GET app.MapGet("/api/reservations/start/{startLocationId}/{startDate}/end/{endLocationId}/{endDate}" - RESPONSE {string CarModel.Name, int CarId, dec Price}[]
    POST app.MapPost("/api/reservations") - body {JSON} - {int CarId, int StartLocationId, int EndLocationId, DateTime StartDate, DateTime EndDate, string FirstName, string LastName, string Email, decimal Price} - RESPONSE { ok, problem }
```
