using BookLibraryProject.Domain.Models;
using BookLibraryProject.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryProject.Data.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;

        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> SearchAsync(string field, string value)
        {
            if (string.IsNullOrWhiteSpace(field) || string.IsNullOrWhiteSpace(value))
                return new List<Book>();

            value = value.ToLower();

            IQueryable<Book> query = _context.Books;

            switch (field.ToLower())
            {
                case "author":
                    query = query.Where(b =>
                        EF.Functions.Like(b.FirstName.ToLower(), $"%{value}%") ||
                        EF.Functions.Like(b.LastName.ToLower(), $"%{value}%"));
                    break;

                case "isbn":
                    query = query.Where(b =>
                        b.ISBN.ToLower().Contains(value));
                    break;

                case "status":
#pragma warning disable CS8602 // Desreferência de uma referência possivelmente nula.
                    query = query.Where(b =>
                        b.Type.ToLower() == value); // exemplo: own/love/want
#pragma warning restore CS8602 // Desreferência de uma referência possivelmente nula.
                    break;

                default:
                    return new List<Book>(); // ou lançar exceção
            }

            return await query.ToListAsync();
        }
    }

}
