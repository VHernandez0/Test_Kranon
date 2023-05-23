using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Net.WebRequestMethods;

namespace SL_Kranon.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        [Route("api/Libro/Add")]
        public IActionResult Add([FromBody] ML.Autor autor)
        {
            ML.Result result = BL.Libro.Add(autor);
            if (result.Correct)
            {
                return Ok (result);
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
            ML.Result result = BL.Libro.GetAll();
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
            ML.Result result = BL.Libro.Delete(IdLibro);
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
