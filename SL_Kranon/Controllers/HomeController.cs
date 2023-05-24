using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Net.WebRequestMethods;

namespace SL_Kranon.Controllers
{
    public class HomeController : Controller
    {
        //[HttpPost]
        //[Route("api/Libro/Add")]
        //public IActionResult Add([FromBody] ML.Libro libro)
        //{
        //    ML.Result result = BL.Libro.Add(libro);
        //    if (result.Correct)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return NotFound(result.ErrorMessage);
        //    }

        //}

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

        [HttpGet]
        [Route("api/Libro/GetByAutor {IdAutor}")]
        public IActionResult GetByAutor( int IdAutor)
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor = IdAutor;
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
        [HttpGet]
        [Route("api/Libro/GetByAutorAndFechaPublicacion {IdAutor}, {Fecha}")]
        public IActionResult GetByAutorAndFechaPublicacion(int IdAutor, string Fecha)
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor = IdAutor;
            libro.AñoPublicacion = Fecha;
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
        [HttpGet]
        [Route("api/Libro/GetByFechaPublicacion {Fecha}")]
        public IActionResult GetByFechaPublicacion(string Fecha)
        {
            ML.Libro libro = new ML.Libro();
            libro.AñoPublicacion = Fecha;
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


        [HttpPost]
        [Route("api/Libro/DeleteforEditorial {IdEditorial}")]
        public IActionResult DeleteforEditorial(int IdEditorial)
        {
            ML.Libro libro = new ML.Libro();
            libro.Editorial = new ML.Editorial();
            libro.Editorial.IdEditorial = IdEditorial;
            ML.Result result = BL.Libro.DeleteForEditorial(libro);
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
        [Route("api/Libro/DeleteforAutor {IdAutor}")]
        public IActionResult DeleteforAutor(int IdAutor)
        {
            ML.Libro libro = new ML.Libro();
            libro.Autor = new ML.Autor();
            libro.Autor.IdAutor = IdAutor;
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
