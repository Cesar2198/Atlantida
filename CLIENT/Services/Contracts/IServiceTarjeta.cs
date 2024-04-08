using CLIENT.Models.ViewModels;

namespace CLIENT.Services.Contracts
{
    public interface IServiceTarjeta
    {
        Task<List<TarjetaCreditoVM>> ObtenerTarjetasCredito();     
    }
}
