using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Net.WebRequestMethods;

namespace SL_Kranon.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("api/Libro/Add")]
        public IActionResult Add([FromBody] ML.Libro libro)
        {
            ML.Result result = BL.Libro.Add(libro);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result.ErrorMessage);
            }

        }

        [HttpGet]
        [Route("api/Libro/Update")]
        public IActionResult Update(ML.Libro libro)
        {


            ML.Result result = BL.Libro.Update(libro);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result.ErrorMessage);
            }
        }

        [HttpPost]
        [Route("api/Libro/GetByAutor")]
        public IActionResult GetByAutor([FromBody] ML.Libro libro)
        {

            ML.Result result = BL.Libro.GetByAutor(libro);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result.ErrorMessage);
            }
        }
        [HttpPost]
        [Route("api/Libro/GetByAutorAndFechaPublicacion")]
        public IActionResult GetByAutorAndFechaPublicacion([FromBody] ML.Libro libro)
        {

            ML.Result result = BL.Libro.GetByAutorAndFechaPublicacion(libro);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result.ErrorMessage);
            }
        }
        [HttpPost]
        [Route("api/Libro/GetByFechaPublicacion")]
        public IActionResult GetByFechaPublicacion([FromBody] ML.Libro libro)
        {
            ML.Result result = BL.Libro.GetByFechaPublicacion(libro);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound(result.ErrorMessage);
            }
        }
    }
}
