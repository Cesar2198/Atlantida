using CLIENT.Models.ViewModels;
using CLIENT.Services.Contracts;
using System.Text;
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

        public async Task<TarjetaCreditoVM> getTarjetaInfo(int id, string numeroTarjeta)
        {
            // Crear un objeto anónimo con los datos que deseas enviar
            var requestData = new
            {
                id,
                numeroTarjeta
            };

            // Serializar el objeto a JSON
            var jsonData = JsonSerializer.Serialize(requestData);

            // Crear un objeto StringContent con el JSON serializado
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            // Realizar la solicitud POST al servicio web
            HttpResponseMessage response = await _httpClient.PostAsync("http://localhost:5100/api/Tarjeta/detail", content);

            // Verificar si la solicitud fue exitosa (código de estado 200)
            if (response.IsSuccessStatusCode)
            {
                // Leer el contenido de la respuesta como una cadena JSON y deserializarla en un objeto TarjetaCreditoVM
                var jsonString = await response.Content.ReadAsStringAsync();
                var tarjetaCreditoVM = JsonSerializer.Deserialize<TarjetaCreditoVM>(jsonString);
                return tarjetaCreditoVM;
            }
            else
            {
                // Si la solicitud no fue exitosa, manejar el error adecuadamente (lanzar una excepción, devolver un valor predeterminado, etc.)
                throw new Exception($"Error al obtener la información de la tarjeta. Código de estado: {response.StatusCode}");
            }
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
