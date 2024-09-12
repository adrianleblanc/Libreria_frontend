using libreria_frontend.Models;

namespace libreria_frontend.Servicios
{
    public interface IServicio_API
    {
        Task<OperationResult> CrearAutor(Autor autor);
        Task<OperationResult> CrearLibro(Libro autor);
        Task<ResultadoBusqueda> Buscar(string keywords, string rut, string author, string title, int? year);
    }
}
