
using BookLibraryProject.Application.Services;
using BookLibraryProject.Data;
using BookLibraryProject.Data.Repository;
using BookLibraryProject.Domain.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BookLibraryProject.IoC;

public static class AppServicesCollectionExtensions
{
    public static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
    {
        ////var dbPath = Path.Combine(environment.ContentRootPath, "books.db");
        ////var connectionString = $"Data Source={dbPath}";

        ////services.AddDbContext<AppDbContext>(options =>
        ////   options.UseSqlite(connectionString));

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookService, BookService>();

        AddSwaggerDocumentation(services);
    }

    public static void AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Book Library API",
                Version = "v1"
            });
        });

        
    }
}
