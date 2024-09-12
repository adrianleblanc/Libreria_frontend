using libreria_frontend.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace libreria_frontend.Controllers
{
    public class BusquedaController : Controller
    {
        private readonly IServicio_API _servicioApi;

        public BusquedaController(IServicio_API servicioApi)
        {
            _servicioApi = servicioApi;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Busqueda(string keywords, string rut, string author, string title, int? year)
        {
            var results = await _servicioApi.Buscar(keywords, rut, author, title, year);
            return PartialView("_ResultadoBusqueda", results);
        }
    }
}
