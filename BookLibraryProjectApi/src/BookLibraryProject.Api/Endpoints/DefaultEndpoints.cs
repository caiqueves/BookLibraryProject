using BookLibraryProject.Application.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace BookLibraryProject.Api.Endpoints
{
    public static class DefaultEndpoints
    {
        public static void MapEndpoints(this WebApplication app)
        {
            app.MapGet("/BookLibrary/search", async (
                string field,
                string value,
                IBookService service) =>
            {
                var books = await service.SearchAsync(field, value);
                return Results.Ok(books.ToList());
            })
            .WithName("SearchBooks");

        }
    }
}
