using BookLibraryProject.Domain.Models;

namespace BookLibraryProject.Domain.Repository
{
    public interface IBookRepository
    {
        Task<List<Book>> SearchAsync(string field, string value);
    }
}
