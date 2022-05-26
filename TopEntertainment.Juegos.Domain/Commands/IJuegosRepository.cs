using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.Domain.Commands
{
    public interface IJuegosRepository
    {
        void Add(Juego juego, List<int> categorias);
        void Update(int id, Juego juego, List<int> categorias);
        void Delete(int id);
        List<Juego> GetAllJuegos();
        Juego GetJuegoById(int id);
        List<int> GetCategoriasByJuegoId(int id);
        void AddCategoria(ProductoCategoria categoria);
        void AddCategorias(int id, List<int> categorias);
        public void DeleteCategoria(int juegoID);
    }
}
