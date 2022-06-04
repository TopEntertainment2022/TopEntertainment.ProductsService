using TopEntertainment.Juegos.Domain.Commands;
using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.AccessData.Commands
{
    public class ClasificacionRepository : IClasificacionRepository
    {

        private readonly JuegosContext _context;

        public ClasificacionRepository(JuegosContext context)
        {
            _context = context;
        }


        public void Add(Clasificacion clasificacion)
        {
            _context.Clasificaciones.Add(clasificacion);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var list = _context.Clasificaciones;
            list.Remove(GetClasificacionById(id));
            _context.SaveChanges();
        }

        public List<Clasificacion> GetAllClasificacion()
        {
            return _context.Clasificaciones.ToList();
        }

        public Clasificacion GetClasificacionById(int id)
        {
            return _context.Clasificaciones.Find(id);
        }

        public Clasificacion GetClasificacionByName(string name)
        {
            return _context.Clasificaciones.SingleOrDefault(p => p.NombreClasificacion == name);
        }

        public void Update(Clasificacion clasificacion)
        {
            var clasificacionEntity = _context.Clasificaciones.Find(clasificacion.ClasificacionId);
            clasificacionEntity = clasificacion;
            _context.SaveChanges();
        }

        public bool ClasificacionIsEmpty(int id)
        {
            var Juegos = _context.Juegos.Where(juego => juego.ClasificacionId == id).ToList();
            if (Juegos.Count == 0) { return true; }
            else return false;
        }

    }
}
