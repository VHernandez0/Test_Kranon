using Microsoft.AspNetCore.Mvc;

namespace SL_Kranon.Controllers
{
    public class LibroController : Controller
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
        [Route("api/Libro/GetAll")]
        public IActionResult GetAll()
        {

            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Editorial = new ML.Editorial();
            libro.Autor = new ML.Autor();
            ML.Result result = BL.Libro.Busqueda(libro);
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
        [Route("api/Libro/GetAll")]
        public IActionResult GetAll([FromBody] ML.Libro libro)
        {

            ML.Result result = BL.Libro.Busqueda(libro);
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
        [Route("api/Libro/delete")]
        public IActionResult delete([FromBody] int IdLibro)
        {
            ML.Libro libro = new ML.Libro();
            libro.IdLibro = IdLibro;
            ML.Result result = BL.Libro.DeleteForAutor(libro);
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
