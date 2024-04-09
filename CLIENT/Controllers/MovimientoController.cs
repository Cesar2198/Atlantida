using CLIENT.Models.ViewModels;
using CLIENT.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CLIENT.Controllers
{
    public class MovimientoController : Controller
    {
        private readonly IServiceMovimientosTarjeta _serviceMovimientos;

        public MovimientoController(IServiceMovimientosTarjeta serviceMovimientos)
        {
            _serviceMovimientos = serviceMovimientos;
        }

        [HttpGet]
        public async Task<IActionResult> Listado(int id, string numeroTarjeta, int mes, int anio)
        {
            int tipo = 1;
            List<MovimientosTarjetaVM> movimientos = await _serviceMovimientos.ObtenerMovimientosTarjeta(id, numeroTarjeta, tipo, mes, anio);
            return View(movimientos);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
