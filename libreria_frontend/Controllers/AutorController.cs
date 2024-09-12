using libreria_frontend.Models;
using libreria_frontend.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace libreria_frontend.Controllers
{
    public class AutorController : Controller
    {
        private IServicio_API _servicioApi;

        public AutorController(IServicio_API servicioApi)
        {
            _servicioApi = servicioApi;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearAutor(Autor autor)
        {
            var respuesta = await _servicioApi.CrearAutor(autor);

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
