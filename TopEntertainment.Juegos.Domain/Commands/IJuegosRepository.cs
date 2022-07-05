using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.Domain.Commands
{
    public interface IJuegosRepository
    {
        List<Juego> GetOfertas(int top);
        void Add(Juego juego, List<int> categorias, List<string> Imagenes);
        void Update(int id, Juego juego, List<int> categorias, List<string> Imagenes);
        void Delete(int id);
        List<Juego> GetAllJuegos(int? categoria = null, int? clasificacion = null, int? plataforma = null, string? descripcion = null, int? precioMinimo = null, int? precioMaximo = null);
        Juego GetJuegoById(int id);
        List<Categoria> GetCategoriasByJuegoId(int id);
        void AddCategoria(ProductoCategoria categoria);
        void AddCategorias(int id, List<int> categorias);
        public void DeleteCategorias(int juegoID);
        public List<string> GetImagenesByJuegoId(int id);
        public List<Juego> GetJuegosByPlataformaId(int id);

        public List<Juego> GetJuegosByCategoriaId(int id);

        public List<Juego> GetJuegosByClasificacionId(int id);

        public bool ValidarPlataforma(int id);

        public bool ValidarClasificacion(int id);

        public bool ValidarCategoria(int categoria);

        public bool ValidarJuego(int id);
    }
}
