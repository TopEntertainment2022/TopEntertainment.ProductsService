using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopEntertainment.Juegos.Domain.Commands;
using TopEntertainment.Juegos.Domain.DTOS;
using TopEntertainment.Juegos.Domain.Entities;
using TopEntertainment.Juegos.Domain.Mapper;

namespace TopEntertainment.Juegos.Application.Services
{
    public interface IJuegosService
    {
        List<Juego> GetAllJuegos();
        Juego GetJuegoById(int id);
        Juego GetJuegoByName(string name);
        void Add(JuegoDTO juego);
        void Delete(int id);
        void Update(int id, JuegoDTO juego);

    }
    public class JuegosService : IJuegosService
    {
        private readonly IJuegosRepository _repository;

        public JuegosService(IJuegosRepository repository)
        {
            _repository = repository;
        }

        public void Add(JuegoDTO juego)
        {

            _repository.Add(Mappers.MapperJuego(new Juego(),juego));
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
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
            return _repository.GetJuegoByName(name);
        }

        public void Update(int id, JuegoDTO juego)
        {
            Juego juegoEntity = _repository.GetJuegoById(id);
            _repository.Update(Mappers.MapperJuego(juegoEntity, juego));
        }
    }
}
