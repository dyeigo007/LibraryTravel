using BrowserTravel.LibraryTravel.Core.Entities;
using BrowserTravel.LibraryTravel.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BrowserTravel.LibraryTravel.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {

        private readonly IEditorialService _editorialRepository;

        public EditorialController(IEditorialService editorialRepository)
        {
            _editorialRepository = editorialRepository;
        }
        /// <summary>
        /// permite obtner las editoriales registradas
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _editorialRepository.GetEditoriale());
        }
        /// <summary>
        /// permite adicionar una editoria
        /// </summary>
        /// <param name="editorial">parametro con los datos de la editorial</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Editoriale editorial)
        {
            return Ok(await _editorialRepository.AddEditoriale(editorial));
        }
        /// <summary>
        /// permite actualiar los datos de una editorial
        /// </summary>
        /// <param name="editorial">paramtros de la editorial a actualziar</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> put(Editoriale editorial)
        {
            return Ok(await _editorialRepository.UpdateEditoriale(editorial));
        }
        /// <summary>
        /// permite eliminar una editorial
        /// </summary>
        /// <param name="id">identificador de la editorial a eliminar</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _editorialRepository.DeleteEditoriale(id));
        }
    }
}
