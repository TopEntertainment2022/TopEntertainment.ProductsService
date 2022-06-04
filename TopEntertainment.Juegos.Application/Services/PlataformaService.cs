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
    public interface IPlataformaService
    {
        List<Plataforma> GetAllPlataformas();
        Plataforma GetPlataformaById(int id);
        Plataforma GetPlataformaByName(string name);

        void Add(PlataformaDTO plataforma);
        void Delete(int id);
        void Update(int id, PlataformaDTO plataforma);

    }
    public class PlataformaService : IPlataformaService
    {
        private readonly IPlataformaRepository _repository;

        public PlataformaService(IPlataformaRepository repository)
        {
            _repository = repository;
        }

        public void Add(PlataformaDTO plataforma)
        {

            _repository.Add(Mappers.MapperPlataforma(new Plataforma(),plataforma));
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Plataforma> GetAllPlataformas()
        {
            return _repository.GetAllPlataformas();
        }

        public Plataforma GetPlataformaById(int id)
        {
            return _repository.GetPlataformaById(id);
        }

        public Plataforma GetPlataformaByName(string name)
        {
            return _repository.GetPlataformaByName(name);
        }

        public void Update(int id,PlataformaDTO plataforma)
        {
            Plataforma plataformaEntity = _repository.GetPlataformaById(id);
            _repository.Update(Mappers.MapperPlataforma(plataformaEntity,plataforma));
        }
    }
}
