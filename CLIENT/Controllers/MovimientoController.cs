using Microsoft.AspNetCore.Mvc;

namespace CLIENT.Controllers
{
    public class MovimientoController : Controller
    {
        [HttpGet]
        public IActionResult Listado()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
