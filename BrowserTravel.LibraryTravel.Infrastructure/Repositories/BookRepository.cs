using BrowserTravel.LibraryTravel.Core.Entities;
using BrowserTravel.LibraryTravel.Core.Interface;
using BrowserTravel.LibraryTravel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserTravel.LibraryTravel.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryTravelContext _dbContext;

        public BookRepository(LibraryTravelContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// permite acicionar un libro
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        public async Task<Libro> AddLibro(Libro libro)
        {
            _dbContext.Libros.Add(libro);
            await _dbContext.SaveChangesAsync();
            return libro;
        }
        /// <summary>
        /// permite borrar un libro
        /// </summary>
        /// <param name="id">identificador del libro a eliminar</param>
        /// <returns></returns>
        public async  Task<bool> DeleteLibro(int id)
        {
            var libroFind = _dbContext.Libros.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (libroFind != null)
            {
                _dbContext.Remove(libroFind);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        /// <summary>
        /// permite obtener los libros registrados
        /// </summary>
        /// <returns></returns>
        public async Task<List<Libro>> GetLibro()
        {
            return await _dbContext.Libros.Include(prop=> prop.IdEditorialNavigation).ToListAsync();
        }
        /// <summary>
        /// permite actualziar los libros
        /// </summary>
        /// <param name="libro"></param>
        /// <returns></returns>
        public async Task<bool> UpdateLibro(Libro libro)
        {
            var libroFind = _dbContext.Libros.Where(x => x.Id.Equals(libro.Id)).FirstOrDefault();
            if (libroFind != null)
            {
                libroFind.Isbn = libro.Isbn;
                libroFind.Titulo = libro.Titulo;
                libroFind.Sinopsis = libro.Sinopsis;
                libroFind.NPaginas = libro.NPaginas;                
                libroFind.IdEditorialNavigation = libro.IdEditorialNavigation;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
