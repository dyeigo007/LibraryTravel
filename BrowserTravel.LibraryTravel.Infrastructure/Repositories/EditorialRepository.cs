using BrowserTravel.LibraryTravel.Core.Entities;
using BrowserTravel.LibraryTravel.Core.Interface;
using BrowserTravel.LibraryTravel.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserTravel.LibraryTravel.Infrastructure.Repositories
{

    public class EditorialRepository : IEditorialRepository
    {
        private readonly LibraryTravelContext _dbContext;

        public EditorialRepository(LibraryTravelContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Editoriale> AddEditoriale(Editoriale editorial)
        {
            _dbContext.Editoriales.Add(editorial);
            await _dbContext.SaveChangesAsync();
            return editorial;
        }

        public async Task<bool> DeleteEditoriale(int id)
        {
            var EditorilFind = _dbContext.Editoriales.Where(x => x.Id.Equals(id)).FirstOrDefault();
            if (EditorilFind != null)
            {
                _dbContext.Remove(EditorilFind);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<List<Editoriale>> GetEditoriale()
        {
            return await _dbContext.Editoriales.ToListAsync();
        }

        public async Task<bool> UpdateEditoriale(Editoriale editorial)
        {
            var editorialFind = _dbContext.Editoriales.Where(x => x.Id.Equals(editorial.Id)).FirstOrDefault();
            if (editorialFind != null)
            {
                editorialFind.Nombre = editorial.Nombre;
                editorialFind.Sede = editorial.Sede;
                editorial.Libros = editorial.Libros;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
