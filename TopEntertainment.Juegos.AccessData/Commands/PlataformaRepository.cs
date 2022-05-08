using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopEntertainment.Juegos.Domain.Commands;
using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.AccessData.Commands
{
    public class PlataformaRepository : IPlataformaRepository
    {
        private readonly JuegosContext _context;

        public PlataformaRepository(JuegosContext context)
        {
            _context = context;
        }


        public void Add(Plataforma plataforma)
        {
            _context.Plataformas.Add(plataforma);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var list = _context.Plataformas;
            list.Remove(GetPlataformaById(id));
            _context.SaveChanges();
        }

        public List<Plataforma> GetAllPlataformas()
        {
            return _context.Plataformas.ToList();
        }

        public Plataforma GetPlataformaById(int id)
        {
            return _context.Plataformas.Find(id);
        }

        public Plataforma GetPlataformaByName(string name)
        {
            return _context.Plataformas.SingleOrDefault(p => p.NombrePlataforma == name);
        }

        public void Update(Plataforma plataforma)
        {
            var plataformaEntity = _context.Plataformas.Find(plataforma.PlataformaId);
            plataformaEntity = plataforma;
            _context.SaveChanges();
        }
    
    }

}
