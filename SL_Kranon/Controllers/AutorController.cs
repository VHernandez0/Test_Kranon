using Microsoft.AspNetCore.Mvc;

namespace SL_Kranon.Controllers
{
    public class AutorController : Controller
    {
        [HttpGet]
        [Route("api/Autor/GetAll")]
        public IActionResult GetAll()
        {

            ML.Result result = BL.Autor.GetAll();
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
