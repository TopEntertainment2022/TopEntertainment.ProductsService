using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public void Add(Juego juego)
        {
            _context.Juegos.Add(juego);
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
            return _context.Juegos.ToList();
        }

        public Juego GetJuegoById(int id)
        {
            return _context.Juegos.Find(id);
        }

        public Juego GetJuegoByName(string name)
        {
            return _context.Juegos.SingleOrDefault(Juego => Juego.NombreProducto == name);
        }

        public void Update(Juego juego)
        {
           Juego JuegoEntity =  _context.Juegos.Find(juego.JuegoId);
                JuegoEntity = juego;
                _context.SaveChanges(); 
        }
    }
}
