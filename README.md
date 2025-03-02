# Simple Booking System

## Overview

The **Simple Booking System** is a backend solution for managing resource bookings. It allows users to:

- View available resources.
- Book resources for a specified time.
- Add, edit, and delete resources.
- Handle booking conflicts and resource availability.
- Integrates with **SQLite** for database storage, using **Entity Framework Core**.

## Features

- **Resource Management**: View, add, update, and delete resources.
- **Booking**: Make bookings for resources, checking availability and quantity.
- **Error Handling**: Custom error handling with structured error responses.
- **Validation**: Request validation using **FluentValidation** for all endpoints.
- **Asynchronous Operations**: Non-blocking operations for better performance.

## Technologies

- **ASP.NET Core**: For building the Web API.
- **C#**: Programming language used for backend development.
- **Entity Framework Core**: ORM used to interact with an SQLite database.
- **SQLite**: Database for storing resource and booking data.
- **FluentValidation**: Validation library for input validation.
- **Swagger**: For API documentation and testing.

## Requirements

- **.NET 8.0 SDK** or later
- **SQLite** (for database storage)

## Setup Instructions

### 1. Clone the Repository

Clone the repository to your local machine:
```
git clone https://github.com/vasilevdimitrij/BookingSystem.git
```
```
cd simple-booking-system
```

### 2. Install Dependencies

Restore the necessary dependencies:

```
dotnet restore
```
  
### 3. Set up the Database

The project uses **SQLite** for the database. The database schema is created automatically using **Entity Framework Core** migrations.

Run the migrations to set up the database:

```
dotnet ef database update --project SimpleBookingSystem.Infrastructure --startup-project SimpleBookingSystem.API
```
  
### 4. Run the Application

Run the application using the following command:

```
dotnet run --project SimpleBookingSystem.API
```

This will start the API on `https://localhost:5157` by default.

### 5. Access Swagger UI

You can test the API through the **Swagger UI**. Once the application is running, visit:
`https://localhost:5157/swagger`

## API Endpoints

### **Resources**

- **GET `/api/resources`**: Retrieve all resources.
- **POST `/api/resources`**: Add a new resource.
- **PUT `/api/resources/{id}`**: Update a resource.
- **DELETE `/api/resources/{id}`**: Delete a resource.

### **Bookings**

- **POST `/api/bookings`**: Make a new booking for a resource.
- **GET `/api/bookings`**: Retrieve all bookings.

## Error Handling

All API endpoints implement structured error handling. Common HTTP status codes include:

- **400 Bad Request**: For validation or business rule failures (e.g., insufficient quantity for a booking).
- **404 Not Found**: When a resource or booking does not exist.
- **409 Conflict**: When a booking conflict occurs (e.g., trying to book a resource at an already reserved time).
- **500 Internal Server Error**: For unexpected server-side errors.

## Dependencies

### **Backend Dependencies**:

1. **ASP.NET Core 8.0 SDK**: Required to run and build the project.
2. **Entity Framework Core**: ORM used to interact with the SQLite database.
3. **FluentValidation**: For request validation of inputs.

Install these dependencies using the following commands:

 ```
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
```
```
dotnet add package Microsoft.EntityFrameworkCore.Design
```
```
dotnet add package FluentValidation.AspNetCore
```


### **Additional Dependencies**:

1. **Swagger**: For API documentation and testing.
2. **SQLite**: Database used to store resource and booking data.

### **How to Use the API**

1. **Adding a Resource**: 
   - Use the POST `/api/resources` endpoint to add new resources.
   - Example request:
     ```
     POST /api/resources
     {
       "name": "Projector",
       "quantity": 10
     }
     ```

2. **Making a Booking**: 
   - Use the POST `/api/bookings` endpoint to make bookings.
   - Example request:
     ```
     POST /api/bookings?resourceId=1&quantity=3&startTime=2024-03-01T10:00:00&endTime=2024-03-01T12:00:00
     ```

3. **Viewing Resources**: 
   - Use the GET `/api/resources` endpoint to view all resources.
   
4. **Viewing Bookings**:
   - Use the GET `/api/bookings` endpoint to view all bookings.

---

### License

This project is licensed under the MIT License.




  



