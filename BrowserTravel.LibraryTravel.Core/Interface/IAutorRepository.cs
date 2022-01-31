using BrowserTravel.LibraryTravel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrowserTravel.LibraryTravel.Core.Interface
{
    public interface IAutorRepository
    {
        Task<List<Autore>> GetAutors();
        Task<Autore> AddAutors(Autore autor);
        Task<Boolean> UpdateAutors(Autore autor);
        Task<Boolean> DeleteAutor(int id);

    }
}
