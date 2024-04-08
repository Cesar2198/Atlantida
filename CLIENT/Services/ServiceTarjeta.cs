using CLIENT.Models.ViewModels;
using CLIENT.Services.Contracts;
using System.Text.Json;

namespace CLIENT.Services
{
    public class ServiceTarjeta : IServiceTarjeta
    {
        private readonly HttpClient _httpClient;

        public ServiceTarjeta(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TarjetaCreditoVM>> ObtenerTarjetasCredito()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:5100/api/Tarjeta/List");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                List<TarjetaCreditoVM> tarjetasCredito = JsonSerializer.Deserialize<List<TarjetaCreditoVM>>(jsonString);
                return tarjetasCredito;
            }
            else
            {
                // Manejar el error de alguna manera apropiada
                throw new Exception("Error al obtener las tarjetas de crédito desde la API.");
            }
        }
    }
}
