using BrowserTravel.LibraryTravel.Core.Entities;
using BrowserTravel.LibraryTravel.Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserTravel.LibraryTravel.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorRepository _autorRepository;

        public AutorController(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;
        }
        /// <summary>
        /// permite obtener los autores registrados
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Ok(await _autorRepository.GetAutors());
        }
        /// <summary>
        /// permite adicionar un autor 
        /// </summary>
        /// <param name="autor">objeto que permite </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(Autore autor)
        {
            return Ok(await _autorRepository.AddAutors(autor));
        }

        /// <summary>
        /// permite actualizar un autor
        /// </summary>
        /// <param name="autor">contiene los datos necesarios para la actualización del autor</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> put(Autore autor)
        {
            return Ok(await _autorRepository.UpdateAutors(autor));
        }
        /// <summary>
        /// permite eliminar un autor
        /// </summary>
        /// <param name="id">identificador del autor a eliminar</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _autorRepository.DeleteAutor(id));
        }


    }
}
