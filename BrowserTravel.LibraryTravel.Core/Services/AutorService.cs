using BrowserTravel.LibraryTravel.Core.Entities;
using BrowserTravel.LibraryTravel.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrowserTravel.LibraryTravel.Core.Services
{
    public class AutorService : IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public async Task<Autore> AddAutors(Autore autor)
        {
            return await _autorRepository.AddAutors(autor);
        }

        public async Task<bool> DeleteAutor(int id)
        {
            return await _autorRepository.DeleteAutor(id);
        }

        public async Task<List<Autore>> GetAutors()
        {
            return await _autorRepository.GetAutors();
        }

        public async Task<bool> UpdateAutors(Autore autor)
        {
            return await _autorRepository.UpdateAutors(autor);
        }
    }
}
