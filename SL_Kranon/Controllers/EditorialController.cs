using Microsoft.AspNetCore.Mvc;

namespace SL_Kranon.Controllers
{
    public class EditorialController : Controller
    {
        [HttpGet]
        [Route("api/Editorial/GetAll")]
        public IActionResult GetAll()
        {

            ML.Result result = BL.Editorial.GetAll();
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
