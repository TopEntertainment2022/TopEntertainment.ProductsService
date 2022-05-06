using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopEntertainment.Juegos.Domain.Commands;
using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.Application.Services
{
    public interface IJuegosService
    {
        List<Juego> GetAllJuegos();
        Juego GetJuegoById(int id);
        Juego GetJuegoByName(string name);
        void Add(Juego juego);
        void Delete(int id);
        void Update(Juego juego);
    }
    public class JuegosService : IJuegosService
    {
        private readonly IJuegosRepository _repository;

        public JuegosService(IJuegosRepository repository)
        {
            _repository = repository;
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
            return _repository.GetAllJuegos();
        }

        public Juego GetJuegoById(int id)
        {
            return _repository.GetJuegoById(id);
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
