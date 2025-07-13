using BookLibraryProject.Domain.Models;


namespace BookLibraryProject.Application.Services
{
    public interface IBookService
    {
        Task<List<Book>> SearchAsync(string field, string value);
    }
}
