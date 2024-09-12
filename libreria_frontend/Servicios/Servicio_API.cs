using libreria_frontend.Models;
using Newtonsoft.Json;
using System.Text;

namespace libreria_frontend.Servicios
{
    public class Servicio_API : IServicio_API
    {
        private static string _baseUrl;

        public Servicio_API()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            _baseUrl = builder.GetSection("ApiSetting:Url").Value;
        }

        public async Task<OperationResult> CrearAutor(Autor autorDTO)
        {
            var cliente = new HttpClient { BaseAddress = new Uri(_baseUrl) };
            var content = new StringContent(JsonConvert.SerializeObject(autorDTO), Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PostAsync("api/Autor/crearAutor", content);
                if (response.IsSuccessStatusCode)
                {
                    return new OperationResult
                    {
                        IsSuccess = true,
                        Message = "Autor creado con éxito."
                    };
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    return new OperationResult
                    {
                        IsSuccess = false,
                        Message = $"Error al crear autor: {response.StatusCode} - {errorMessage}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    IsSuccess = false,
                    Message = $"Error de comunicación: {ex.Message}"
                };
            }
        }

        public async Task<OperationResult> CrearLibro(Libro libroDTO)
        {
            var cliente = new HttpClient { BaseAddress = new Uri(_baseUrl) };
            var content = new StringContent(JsonConvert.SerializeObject(libroDTO), Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PostAsync("api/Libro/crearLibro", content);

                if (response.IsSuccessStatusCode)
                {
                    return new OperationResult
                    {
                        IsSuccess = true,
                        Message = "Libro creado con éxito."
                    };
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    return new OperationResult
                    {
                        IsSuccess = false,
                        Message = $"Error al crear libro: {response.StatusCode} - {errorMessage}"
                    };
                }
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    IsSuccess = false,
                    Message = $"Error de comunicación: {ex.Message}"
                };
            }
        }

        public async Task<ResultadoBusqueda> Buscar(string keywords, string rut, string author, string title, int? year)
        {
            var cliente = new HttpClient { BaseAddress = new Uri(_baseUrl) };

            var queryString = $"?keywords={keywords}&rut={rut}&author={author}&title={title}&year={year}";
            var response = await cliente.GetAsync($"api/Busqueda/buscar{queryString}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ResultadoBusqueda>(jsonString);
            }
            else
            {
                throw new Exception("Error en la búsqueda.");
            }
        }
    }
}
