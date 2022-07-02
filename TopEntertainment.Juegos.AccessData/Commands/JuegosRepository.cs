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


        public void Add(Juego juego, List<int>? categorias, List<string>? Imagenes)
        {
            _context.Juegos.Add(juego);
            _context.SaveChanges();
            if (categorias != null)
            {
                AddCategorias(juego.JuegoId, categorias);
            }
            if (Imagenes != null)
            {
                AddImagenes(juego.JuegoId, Imagenes);
            }
            _context.SaveChanges();
        }

        public void Update(int id, Juego juego, List<int>? categorias, List<string>? Imagenes)
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
            if (categorias != null)
            {
                DeleteCategorias(JuegoEntity.JuegoId);
                AddCategorias(JuegoEntity.JuegoId, categorias);
            }
            if (Imagenes != null)
            {
                DeleteImagenes(JuegoEntity.JuegoId);
                AddImagenes(JuegoEntity.JuegoId, Imagenes);
            }
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Juego juego = _context.Juegos.Find(id);
            juego.SoftDelete = true;
            _context.SaveChanges();
        }

        public List<Juego> GetAllJuegos(int? categoria=null, int? clasificacion = null, int? plataforma = null, string? descripcion = null)
        {
            return _context.Juegos.Where(juego => juego.SoftDelete == false &&
                                          (clasificacion == null || juego.ClasificacionId == clasificacion.Value) &&
                                          (plataforma == null || juego.PlataformaId == plataforma.Value) &&
                                          (string.IsNullOrEmpty(descripcion) || juego.NombreProducto.Contains(descripcion))
            ).ToList();
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

        public List<string> GetImagenesByJuegoId(int id)
        {
            return _context.Imagenes.
                                             Where(imagen => imagen.JuegoId == id).
                                             Select(imagen => imagen.ImagenUrl).
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

        public void DeleteCategorias(int juegoID)
        {
            var categorias = _context.ProductoCategoria.Where(productoCategoria => productoCategoria.JuegoId == juegoID).ToList();
            foreach (ProductoCategoria categoria in categorias)
            {
                _context.ProductoCategoria.Remove(categoria);
            }
        }

        public void AddImagen(Imagen imagen)
        {
            _context.Imagenes.Add(imagen);
        }

        public void AddImagenes(int id, List<string> Imagenes)
        {
            foreach (var imagen in Imagenes)
            {
                AddImagen(new Imagen(imagen, id));
            }
        }

        public void DeleteImagenes(int juegoID)
        {
            var Imagenes = _context.Imagenes.Where(imagen => imagen.JuegoId == juegoID).ToList();
            foreach (var imagen in Imagenes)
            {
                _context.Imagenes.Remove(imagen);
            }
        }

        public List<Juego> GetJuegosByPlataformaId(int id)
        {
            return _context.Juegos.Where(juego => juego.SoftDelete == false && juego.PlataformaId == id).ToList();
        }

        public List<Juego> GetJuegosByCategoriaId(int id)
        {
            var listaJuegos = (
            from c in _context.ProductoCategoria
            join j in _context.Juegos on c.JuegoId equals j.JuegoId
            where c.CategoriaId == id
            select c.Juego).ToList();

            return listaJuegos;
        }

        public List<Juego> GetJuegosByClasificacionId(int id)
        {
            return _context.Juegos.Where(juego => juego.SoftDelete == false && juego.ClasificacionId == id).ToList();
        }

        public bool ValidarPlataforma(int id)
        {
            if (_context.Plataformas.Find(id) == null)
            {
                return false;
            }
            else return true;

        }

        public bool ValidarClasificacion(int id)
        {
            if (_context.Clasificaciones.Find(id) == null)
            {
                return false;
            }
            else return true;

        }

        public bool ValidarCategoria(int categoria)
        {
            if (_context.Categoria.Find(categoria) == null)
            {
                return false;
            }
            else return true;
        }

        public bool ValidarJuego(int id)
        {
            if (_context.Juegos.SingleOrDefault(juego => juego.SoftDelete == false && juego.JuegoId == id) == null)
            {
                return false;
            }
            else return true;
        }
    }
}
