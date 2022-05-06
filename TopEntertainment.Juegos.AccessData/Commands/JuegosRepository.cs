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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Update(Juego juego)
        {
            throw new NotImplementedException();
        }
    }
}
