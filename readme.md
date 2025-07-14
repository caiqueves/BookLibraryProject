# 📚 Library Book - Backend API

This is the backend of a library book management application. The API is built with ASP.NET Core and uses Entity Framework Core to query data.

---

## 🚀 Technologies Used

- **.NET 9** – Core development platform
- **ASP.NET Core Minimal API** – Framework for creating RESTful endpoints
- **Entity Framework Core** – ORM for database access
- **SQLite** – Simple and lightweight local database
- **Swagger (Swashbuckle)** – Interactive API documentation

---

## 🛠️ Project Structure

- **/BookLibraryProject.Api → Presentation layer (Minimal API, Program.cs, Controllers)
- **/BookLibraryProject.Domain → Entities, repository interfaces, and pure business rules
- **/BookLibraryProject.App → Use cases (Application Layer), DTOs, and application services
- **/BookLibraryProject.Data → Repository implementations, DbContext, and Migrations
- **/BookLibraryProject.IoC → Dependency injection and service configuration


## 📘 Endpoints Principais

- **GET /BookLibrary/search – List books by field and value


## 📦 How to Run the Project

1. Clone the repository:

```bash
git clone https://github.com/caiqueves/BookLibraryProject.git

2. Access backend project

```bash
cd BookLibraryProjectApi
```

3. Run the migrations command at the project root

```bash
dotnet ef database update
```

4. Configurar o Cors do React

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
```

5. Rodar o projeto

```bash
dotnet run
```

6. Access frontEnd project

```bash
cd book-library-project
```

7. Restore packages

```bash
npm install
```

8. Run the frontend

```bash
npm start
```

