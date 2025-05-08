# TeslaRent-01.WebApplication

Project assumptions (09.05.2025):
```
1. Locations: 
	1. Palma Airport
	2. Palma City Center
	3. Alcudia
	4. Manacor

2.  Car Models (daily price -6days/7-29days/30+days) 
	1. Tesla Model 3 (220/200/165) - 16 vehicles
	2. Tesla Model Y (350/315/270) - 10 vehicles
	3. Tesla Model S (500/450/375) - 6 vehicles
	4. Tesla Model X (650/600/500) - 6 vehicles
	5. Tesla Cybertruck (700/640/525) - 2 vehicles

3.  Tables
	1. Reservations (Id, CarId, StartLocationId, StartDate, EndLocationId, EndDate, Price, Email, FirstName, LastName)
	2. Cars (Id, CarModelId, DayInService)
	3. CarModels (Id, Name, DailyRateShortTerm, DailyRateMidTerm, DailyRateLongTerm)
	4. Locations (Id, Name, Country, City, Postcode, Street, StreetNumber)

4.  Endpoints
	1. GET /api/location
		Response body:
		[
		  {
		    "id": 1,
		    "name": "Palma Airport"
		  },
		  {
		    "id": 2,
		    "name": "Palma City Center"
		  },
		  {
		    "id": 3,
		    "name": "Alcudia"
		  },
		  {
		    "id": 4,
		    "name": "Manacor"
		  }
		]

	2. GET /api/start_location/{startLocationId}/start_date/{startDate}/end_location/{endLocationId}/end_date/{endDate}
		Response body:
		[
		  {
		    "id": 1,
		    "name": "Tesla Model 3",
		    "price": 220
		  },
		  {
		    "id": 2,
		    "name": "Tesla Model Y",
		    "price": 350
		  },
		  {
		    "id": 3,
		    "name": "Tesla Model S",
		    "price": 500
		  },
		  {
		    "id": 4,
		    "name": "Tesla Model X",
		    "price": 650
		  },
		  {
		    "id": 5,
		    "name": "Tesla Cybertruck",
		    "price": 700
		  }
		]
	3. POST api/reservation
		Request body:
		{
		  "startLocationId": 1,
		  "endLocationId": 1,
		  "startDate": "2025-05-09",
		  "endDate": "2025-05-10",
		  "carModelId": 1,
		  "firstName": "tesla",
		  "lastName": "rent",
		  "email": "tesla@rent.com",
		  "price": 200.00
		}
		Response:
		Code 200 OK

5. Views:
	1. Search form - use of GET /api/location to get list of locations - 4 fields in the form startLocation, endLocation, startDate, endDate
	2. Car List - use of GET /api/start_location/{startLocationId}/start_date/{startDate}/end_location/{endLocationId}/end_date/{endDate}
	3. User data form - add firstName, lastName, email, carModelId
	4. Positive response screen
```
