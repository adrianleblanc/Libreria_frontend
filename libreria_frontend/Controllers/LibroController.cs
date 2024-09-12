using libreria_frontend.Models;
using libreria_frontend.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace libreria_frontend.Controllers
{
    public class LibroController : Controller
    {
        private readonly IServicio_API _servicioApi;

        public LibroController(IServicio_API servicioApi)
        {
            _servicioApi = servicioApi;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GuardarLibro(Libro libro)
        {
            var respuesta = await _servicioApi.CrearLibro(libro);

            if (respuesta.IsSuccess)
            {
                TempData["SuccessMessage"] = respuesta.Message;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["ErrorMessage"] = respuesta.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
