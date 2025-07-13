using BookLibraryProject.Domain.Models;
using BookLibraryProject.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryProject.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Book>> SearchAsync(string field, string value)
        {
            return await _repository.SearchAsync(field, value);
        }
    }
}


