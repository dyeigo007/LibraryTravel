using BrowserTravel.LibraryTravel.Core.Entities;
using BrowserTravel.LibraryTravel.Core.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrowserTravel.LibraryTravel.Core.Services
{
    public class EditorialService : IEditorialService
    {

        private readonly IEditorialRepository _editorialRepository;

        public EditorialService(IEditorialRepository editorialRepository)
        {
            _editorialRepository = editorialRepository;
        }

        public async  Task<Editoriale> AddEditoriale(Editoriale editorial)
        {
            return await _editorialRepository.AddEditoriale(editorial);
        }

        public async Task<bool> DeleteEditoriale(int id)
        {
            return await _editorialRepository.DeleteEditoriale(id);
        }

        public async Task<List<Editoriale>> GetEditoriale()
        {
            return await _editorialRepository.GetEditoriale();
        }

        public async Task<bool> UpdateEditoriale(Editoriale editorial)
        {
            return await _editorialRepository.UpdateEditoriale(editorial);
        }
    }
}
