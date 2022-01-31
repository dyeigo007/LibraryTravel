using BrowserTravel.LibraryTravel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrowserTravel.LibraryTravel.Core.Interface
{
    public interface IBookRepository
    {
        Task<List<Libro>> GetLibro();
        Task<Libro> AddLibro(Libro libro);
        Task<Boolean> UpdateLibro(Libro libro);
        Task<Boolean> DeleteLibro(int id);
    }
}
