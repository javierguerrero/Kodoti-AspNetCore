using Microsoft.AspNetCore.Mvc;

namespace KODOTI_MVC.Controllers
{
    [Route("Cursos")]
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpGet("descuentos")]
        public IActionResult LastCoursesOffers()
        {
            return Ok("Página de descuento");
        }
    }
}