using CLIENT.Models.ViewModels;
using CLIENT.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CLIENT.Controllers
{
    public class TarjetaController : Controller
    {
        private readonly IServiceTarjeta _serviceTarjeta;

        public TarjetaController(IServiceTarjeta serviceTarjeta)
        {
            _serviceTarjeta = serviceTarjeta;
        }


        [HttpGet]
        public async Task<IActionResult> Detalles(int id, string numeroTarjeta)
        {
            TarjetaCreditoVM tarjeta = await _serviceTarjeta.getTarjetaInfo(id, numeroTarjeta);
            return View(tarjeta);
        }

    }
}
