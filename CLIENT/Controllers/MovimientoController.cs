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
            // Ordenar los movimientos por fecha de forma descendente (la más reciente primero)
            movimientos = movimientos.OrderByDescending(m => m.fechaMovimiento).ToList();
            return View(movimientos);
        }

        [HttpGet]
        public IActionResult Movimiento(int idTarjeta, int tipoMovimiento)
        {
            ViewBag.tipoMovimiento = tipoMovimiento;
            ViewBag.idTarjeta = idTarjeta;
            MovimientosTarjetaVM movimiento = new();
            movimiento.idTarjeta = idTarjeta;
            movimiento.tipoMovimiento = tipoMovimiento.ToString();
            movimiento.monto = 0;
            return View(movimiento);
        }

        [HttpPost]
        public async Task<IActionResult> Movimiento(MovimientosTarjetaVM movimiento)
        {

            if (!ModelState.IsValid)
            {
                return PartialView(movimiento);
            }
            try
            {

                if (movimiento.tipoMovimiento == "2")
                {
                    movimiento.monto = movimiento.monto * -1;
                }
                movimiento.fechaMovimiento = System.DateTime.Now;
                await _serviceMovimientos.GuardarMovimiento(movimiento);
                return Json(new { estado = "Todo bien" });
            }
            catch (Exception)
            {

                return Json(new { estado = "Error" });
            }
        }
    }
}
