# Book Library API & Frontend

A simple RESTful minimal API built with ASP.NET Core for managing and searching books, paired with a React frontend for querying and displaying the results.

---

## Table of Contents

- [About the Project](#about-the-project)  
- [Technologies Used](#technologies-used)  
- [Backend Setup](#backend-setup)  
- [Frontend Setup](#frontend-setup)  
- [Creating and Populating the `books.json` File](#creating-and-populating-the-booksjson-file)  
- [Running the Application](#running-the-application)  
- [Available API Endpoints](#available-api-endpoints)  
- [Usage Instructions](#usage-instructions)  
- [Contributing](#contributing)  
- [License](#license)  

---

## About the Project

This project consists of:

- A minimal REST API built with ASP.NET Core exposing an endpoint to search books dynamically based on a field and value.  
- A React frontend application that allows users to query books by different fields and view the search results.

The API returns JSON-formatted data representing book records.

---

## Technologies Used

- **Backend:**  
  - .NET 9+ (Minimal APIs)  
  - C#  
  - Entity Framework Core (Code First)  
  - Repository Design Pattern  
  - Database Migrations with EF Core  
- **Frontend:**  
  - React (JavaScript)  
- **Data Storage:**  
  - Relational database (e.g., SQL Server, PostgreSQL, SQLite) via EF Core  

---

## Backend Setup

1. **Clone the repository** and open the backend project in your IDE (Visual Studio, VS Code, etc).
```bash
git clone https://github.com/caiqueves/BookLibraryProject.git
```

2. **Configure CORS** to allow the React frontend (usually running on `http://localhost:3000`) to access the API.  
Add this in your `Program.cs` before building the app:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReact", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors("AllowReact");

// Map your endpoints here
// e.g. app.MapEndpoints();

app.Run();

```csharp
---

2. **Configure Migrations** Running EF Core Migrations

Entity Framework Core uses migrations to create and update your database schema based on your model classes.

Follow these steps to create and apply migrations:

2.1. **Create a migration** that captures a snapshot of the current model by running the command at the project root:

```bash
dotnet ef migrations script --project BookLibraryProject.Data --startup-project BookLibraryProject.Api
```

2.2 **Update Database 

```bash
dotnet ef database update --project BookLibraryProject.Data --startup-project BookLibraryProject.Api
```

3. ** Execute Backend



## Front Setup

1. **Open the frontEnd repository** in your IDE (Visual Studio, VS Code, etc).

```bash
npm install
```

2. ** Execute FrontEnd

```bash
npm start
```
