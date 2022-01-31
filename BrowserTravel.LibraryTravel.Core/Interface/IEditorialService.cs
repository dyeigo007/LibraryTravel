using BrowserTravel.LibraryTravel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrowserTravel.LibraryTravel.Core.Interface
{
    public interface IEditorialService
    {
        Task<List<Editoriale>> GetEditoriale();
        Task<Editoriale> AddEditoriale(Editoriale editorial);
        Task<Boolean> UpdateEditoriale(Editoriale editorial);
        Task<Boolean> DeleteEditoriale(int id);
    }
}
