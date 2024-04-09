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

        [HttpGet]
        public IActionResult Movimiento(int idTarjeta, int tipoMovimiento)
        {
            ViewBag.tipoMovimiento = tipoMovimiento;
            ViewBag.idTarjeta = idTarjeta;
            return View();
        }

        [HttpPost]
        public IActionResult Movimiento(MovimientosTarjetaVM movimientos)
        {
            return View();
        }
    }
}
