using BrowserTravel.LibraryTravel.Core.Entities;
using BrowserTravel.LibraryTravel.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrowserTravel.LibraryTravel.Core.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Libro> AddLibro(Libro libro)
        {
            return await _bookRepository.AddLibro(libro);
        }

        public async Task<bool> DeleteLibro(int id)
        {
            return await _bookRepository.DeleteLibro(id);
        }

        public async Task<List<Libro>> GetLibro()
        {
            return await _bookRepository.GetLibro();
        }

        public async Task<bool> UpdateLibro(Libro libro)
        {
            return await _bookRepository.UpdateLibro(libro);
        }
    }
}
