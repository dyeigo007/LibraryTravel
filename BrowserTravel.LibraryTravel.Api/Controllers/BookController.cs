using BrowserTravel.LibraryTravel.Core.Entities;
using BrowserTravel.LibraryTravel.Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BrowserTravel.LibraryTravel.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookService _bookRepository;

        public BookController(IBookService bookRepository)
        {
            _bookRepository = bookRepository;
        }
        /// <summary>
        /// permite obtener todos los libros registados
        /// </summary>
        /// <returns>no requiere parametros</returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _bookRepository.GetLibro());
        }
        /// <summary>
        /// permite alamacenar un nuevo libro
        /// </summary>
        /// <param name="libro">objeto que contine las propiedades para almacenar un libro</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Libro libro)
        {
            return Ok(await _bookRepository.AddLibro(libro));
        }
        /// <summary>
        /// permite actualizar un libro
        /// </summary>
        /// <param name="libro">contine las nuevas caracteristicas del libro para ser actualziado</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> put(Libro libro)
        {
            return Ok(await _bookRepository.UpdateLibro(libro));
        }
        /// <summary>
        /// permite eliminar un libro
        /// </summary>
        /// <param name="id">identificador del libro para ser eliminado</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _bookRepository.DeleteLibro(id));
        }
    }
}
