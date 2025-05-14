# TeslaRent-01.WebApplication

**TeslaRent** is a web application designed to create reservations for all passenger Tesla Cars.

## 🚀 Technologies

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-512BD4?style=for-the-badge&logo=.net&logoColor=white)
![TypeScript](https://img.shields.io/badge/TypeScript-3178C6?style=for-the-badge&logo=typescript&logoColor=white)
![React](https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB)
![SendGrid](https://img.shields.io/badge/SendGrid-008CE7?style=for-the-badge&logo=sendgrid&logoColor=white)
![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white)
![MSSQL](https://img.shields.io/badge/MSSQL-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=.net&logoColor=white)

---

## 📦 **Preview**

### Car List page
![image](https://github.com/user-attachments/assets/78fcb788-665f-4625-9e6f-f1b95d7560f8)

### Home Page
![image](https://github.com/user-attachments/assets/fba10471-6a9e-4ee8-bbe3-2a6ac08bd702)

---

## 📋 **Project assumptions**

### 🌍 Locations
```
1. Palma Airport
2. Palma City Center
3. Alcudia
4. Manacor
```

### 🚗 Car Models (daily price) 
```
1. Tesla Model 3 (220€/200€/165€) - 16 vehicles
2. Tesla Model Y (350€/315€/270€) - 10 vehicles
3. Tesla Model S (500€/450€/375€) - 6 vehicles
4. Tesla Model X (650€/600€/500€) - 6 vehicles
5. Tesla Cybertruck (700€/640€/525€) - 2 vehicles
```

### 📊 Business logic
```
1. Cars can be reserved daily
2. Cars have discounts if they are reserved for 7-29days and even bigger discount for 30+ days
3. In order to pickup the car, customer has to pay deposit which is 30% of total rental price
4. Customer can pick up the car in chosen location and return it to any location selected
5. Cars are searched based on availability. Reservations for a single car do not overlap.
   If a car is available for the selected dates but already has a subsequent reservation, it is checked whether
   the end location of the current search matches the start location of the existing reservation, and vice versa.
   After selecting a model, cars with the lowest "DaysInService" that meet the remaining criteria are chosen.
```

---

## 🗃️ Database

### 🚗 Cars
```
Id [INT]
CarModelId [INT] - FK
DaysInService [INT]
```
### 🚙 CarModels
```
Id [INT]
Name [STR]
BodyType [STR]
Description [STR]
DailyRateShortTerm [DEC]
DailyRateMidTerm [DEC]
DailyRateLongTerm [DEC]
Seats [INT]
MaxSpeed [INT]
MaxRange [INT]
Acceleration [DEC]
```
### 📍 Locations
```
Id [INT]
Name [STR]
Country [STR]
City [STR]
ZipCode [STR]
Street [STR]
StreetNumber [STR]
```
### 📝 Reservations
```
Id [INT]
CarId [INT]
Car [INT]
StartLocationId [INT] - FK
EndLocationId [INT] - FK
StartDate [DATE]
EndDate [DATE]
FirstName [STR]
LastName [STR]
Email [STR]
PhoneNumber [STR]
Price [DEC]
```

---

## 📘 API Documentation
### 📍 GET `/api/location`

**Description:**  
Retrieves all available rental locations.

**Parameters:**  
_None_

**Response:**

```json
[
  { "id": 1, "name": "Palma Airport" },
  { "id": 2, "name": "Palma City Center" },
  { "id": 3, "name": "Alcudia" },
  { "id": 4, "name": "Manacor" }
]
```

---

### 🚗 GET `/api/cars/start_location/{startLocationId}/start_date/{startDate}/end_location/{endLocationId}/end_date/{endDate}`

**Description:**  
Returns a list of available car models based on selected pickup/drop-off locations and rental dates.

**Path Parameters:**

| Name             | Type     | Required | Description             |
|------------------|----------|----------|-------------------------|
| `startLocationId`| `int`    | Yes      | Pickup location ID      |
| `startDate`      | `string` | Yes      | Pickup date (ISO 8601)  |
| `endLocationId`  | `int`    | Yes      | Drop-off location ID    |
| `endDate`        | `string` | Yes      | Return date (ISO 8601)  |

**Response:**
- `400 Bad Request` – Invalid input
- `200 OK` - Response body:

```json
[
  {
    "id": 1,
    "name": "Tesla Model 3",
    "bodyType": "Sedan",
    "description": "A compact electric sedan offering high performance and range. With its sleek design and incredible efficiency, the Model 3 is perfect for city driving and long road trips. Ideal for families looking for an efficient yet fun ride.",
    "dailyPrice": 220,
    "price": 220,
    "seats": 5,
    "maxSpeed": 261,
    "maxRange": 491,
    "acceleration": 3.1
  },
  {
    "id": 2,
    "name": "Tesla Model Y",
    "bodyType": "SUV",
    "description": "A spacious electric SUV with advanced features and great range. With ample space for both passengers and cargo, the Model Y combines practicality with high-tech performance. Perfect for families or adventurous trips with friends.",
    "dailyPrice": 350,
    "price": 350,
    "seats": 5,
    "maxSpeed": 217,
    "maxRange": 499,
    "acceleration": 5
  },
  {
    "id": 4,
    "name": "Tesla Model X",
    "bodyType": "SUV",
    "description": "A premium electric SUV with falcon-wing doors and roomy interior. Offering a spacious cabin and cutting-edge technology, the Model X is ready for any family adventure. Perfect for large families or those who need extra space and style.",
    "dailyPrice": 650,
    "price": 650,
    "seats": 7,
    "maxSpeed": 262,
    "maxRange": 543,
    "acceleration": 2.6
  },
  {
    "id": 5,
    "name": "Tesla Cybertruck",
    "bodyType": "Pickup",
    "description": "A futuristic electric pickup truck built for durability and power. With its tough exterior and impressive capabilities, the Cybertruck is designed to handle heavy-duty tasks with ease. Ideal for those who need a powerful and reliable vehicle for work or family use.",
    "dailyPrice": 700,
    "price": 700,
    "seats": 6,
    "maxSpeed": 210,
    "maxRange": 750,
    "acceleration": 3
  }
]
```

### 📝 POST `/api/reservation`

**Description:**  
Creates a new reservation based on the provided data.

**Request Body:**

```json
{
  "startLocationId": 1,
  "endLocationId": 1,
  "startDate": "2025-05-15",
  "endDate": "2025-05-16",
  "carModelId": 1,
  "carModelName": "Tesla Model 3",
  "firstName": "John",
  "lastName": "Doe",
  "email": "JohnDoe@gmail.com",
  "phoneNumber": "123456789",
  "price": 220
}
```

**Responses:**
- `200 OK` – Reservation created
- `400 Bad Request` – Invalid input

### 📄 POST `/api/reservation/document`

**Description:**  
Generates a `.pdf` reservation document based on the provided data.

**Request Body:**

```json
{
  "startLocation": {
    "name": "Palma Airport",
    "country": "Spain",
    "city": "Palma",
    "zipCode": "07199",
    "street": "Carrer del Camp Franc",
    "streetNumber": "2"
  },
  "endLocation": {
    "name": "Palma Airport",
    "country": "Spain",
    "city": "Palma",
    "zipCode": "07199",
    "street": "Carrer del Camp Franc",
    "streetNumber": "2"
  },
  "reservation": {
    "startLocationId": 1,
    "endLocationId": 1,
    "startDate": "2025-05-14",
    "endDate": "2025-05-15",
    "carModelId": 1,
    "carModelName": "Tesla Model 3",
    "firstName": "John",
    "lastName": "Doe",
    "email": "JohnDoe@gmail.com",
    "phoneNumber": "123456789",
    "price": 220
  }
}
```

**Response:**
- `200 OK` – Returns a `.pdf` file for download

---

## 🚀 How to Run Locally

Follow these steps to run the project locally:

1. **Clone the repository**

   ```bash
   git clone [LINK]
   cd [project-folder]
   ```

2. **Open the solution in Visual Studio**
3. **Add appsettings.json and fill DefaultConnection server name, SendGrid api key and email**
   ```json
   {
	  "ConnectionStrings": {
	    "DefaultConnection": "Server=[SERVERNAME];Database=TeslaRent;Trusted_Connection=True;MultipleActiveResultSets=true;Encrypt=False"
	  },
	  "SendGrid": {
	    "ApiKey": "[APIKEY]",
	    "Email": "[APIEMAIL]"
	  },
	  "Logging": {
	    "LogLevel": {
	      "Default": "Information",
	      "Microsoft.AspNetCore": "Warning"
	    }
	  }
	}
   ```
5. **Install frontend dependencies and build**
   ```bash
   cd [client-folder]
   npm install
   npm run build
   ```
6. **Apply EF Core migrations and create the database**
   ```bash
   dotnet ef database update
   ```
7. **Run the application**
   In Visual Studio: press F5 or click Start Debugging
   Or via CLI:
   ```bash
   dotnet run --project [your-server-project].csproj
   ```
