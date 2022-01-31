using BrowserTravel.LibraryTravel.Core.Entities;
using BrowserTravel.LibraryTravel.Core.Interface;
using BrowserTravel.LibraryTravel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserTravel.LibraryTravel.Infrastructure.Repositories
{
    public class AutorRepository : IAutorRepository
    {

        private readonly LibraryTravelContext _dbContext;

        public AutorRepository(LibraryTravelContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        /// <summary>
        /// metodo que permite adicionar autores a la lista de autores
        /// </summary>
        /// <param name="autor"> parametro con la estructura para adicionar autores</param>
        /// <returns></returns>
        public async Task<Core.Entities.Autore> AddAutors(Autore autor)
        {            
            _dbContext.Autores.Add(autor);
            await _dbContext.SaveChangesAsync();
            return autor;
        }
        /// <summary>
        /// metodo que permite obtener los autores registrados
        /// </summary>
        /// <returns></returns>
        public async Task<List<Core.Entities.Autore>> GetAutors()
        {

            return await _dbContext.Autores.ToListAsync();

        }
        /// <summary>
        /// permite actualizar un autor
        /// </summary>
        /// <param name="autor">contine los datos del autor a actualizar</param>
        /// <returns></returns>
        public async Task<Boolean> UpdateAutors(Core.Entities.Autore autor)
        {
            var autorFind = _dbContext.Autores.Where(x => x.Id.Equals(autor.Id)).FirstOrDefault();
            if (autorFind != null) {
                autorFind.Nombre = autor.Nombre;
                autorFind.Apellidos = autor.Apellidos;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
             
        }
        /// <summary>
        /// metodo que permite borrar un autor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Boolean> DeleteAutor(int id)
        {
             var autorFind = _dbContext.Autores.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (autorFind != null)
            {
                _dbContext.Remove(autorFind);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
