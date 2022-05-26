using TopEntertainment.Juegos.Domain.Commands;
using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.AccessData.Commands
{
    public class JuegosRepository : IJuegosRepository
    {
        private readonly JuegosContext _context;

        public JuegosRepository(JuegosContext context)
        {
            _context = context;
        }


        public void Add(Juego juego, List<int> categorias)
        {
            _context.Juegos.Add(juego);
            _context.SaveChanges();
            AddCategorias(juego.JuegoId, categorias);
            _context.SaveChanges();
        }

        public void Update(int id, Juego juego, List<int> categorias)
        {
            var JuegoEntity = _context.Juegos.Find(juego.JuegoId);
            JuegoEntity.NombreProducto = juego.NombreProducto;
            JuegoEntity.Precio = juego.Precio;
            JuegoEntity.Stock = juego.Stock;
            JuegoEntity.Descripcion = juego.Descripcion;
            JuegoEntity.EnOferta = juego.EnOferta;
            JuegoEntity.Video = juego.Video;
            JuegoEntity.PlataformaId = juego.PlataformaId;
            JuegoEntity.ClasificacionId = juego.ClasificacionId;
            DeleteCategoria(JuegoEntity.JuegoId);
            AddCategorias(JuegoEntity.JuegoId, categorias);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            Juego juego = _context.Juegos.Find(id);
            juego.SoftDelete = true;
            _context.SaveChanges();
        }

        public List<Juego> GetAllJuegos()
        {
            return _context.Juegos.Where(juego => juego.SoftDelete == false).ToList();
        }

        public Juego GetJuegoById(int id)
        {
            return _context.Juegos.Find(id);
        }


        public List<int> GetCategoriasByJuegoId(int id)
        {
            return _context.ProductoCategoria.
                                             Where(productoCategoria => productoCategoria.JuegoId == id).
                                             Select(productoCategoria => productoCategoria.CategoriaId).
                                             ToList();
        }




        public void AddCategoria(ProductoCategoria categoria)
        {
            _context.ProductoCategoria.Add(categoria);
        }

        public void AddCategorias(int id, List<int> categorias)
        {
            foreach (int categoria in categorias)
            {
                AddCategoria(new ProductoCategoria(id, categoria));
            }
        }

        public void DeleteCategoria(int juegoID)
        {
            var categorias = _context.ProductoCategoria.Where(productoCategoria => productoCategoria.JuegoId == juegoID).ToList();
            foreach (ProductoCategoria categoria in categorias)
            {
                _context.ProductoCategoria.Remove(categoria);
            }
        }

    }
}
