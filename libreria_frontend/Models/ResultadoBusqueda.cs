namespace libreria_frontend.Models
{
    public class ResultadoBusqueda
    {
        public IEnumerable<Libro> Libros { get; set; }
        public IEnumerable<Autor> Autores { get; set; }
    }
}
