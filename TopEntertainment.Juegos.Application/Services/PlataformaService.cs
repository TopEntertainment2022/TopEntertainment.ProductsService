using AutoMapper;
using TopEntertainment.Juegos.Domain.Commands;
using TopEntertainment.Juegos.Domain.DTOS;
using TopEntertainment.Juegos.Domain.Entities;
using TopEntertainment.Juegos.Domain.Mapper;

namespace TopEntertainment.Juegos.Application.Services
{
    public interface IPlataformaService
    {
        List<PlataformaDTO2> GetAllPlataformas();
        PlataformaDTO2 GetPlataformaById(int id);
        void Add(PlataformaDTO plataforma);
        void Delete(int id);
        void Update(int id, PlataformaDTO plataforma);

    }
    public class PlataformaService : IPlataformaService
    {
        private readonly IPlataformaRepository _repository;
        private readonly IMapper _mapper;

        public PlataformaService(IPlataformaRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(PlataformaDTO plataforma)
        {

            _repository.Add(_mapper.Map<Plataforma>(plataforma));
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<PlataformaDTO2> GetAllPlataformas()
        {
            var plataformas = new List<PlataformaDTO2>();
            foreach (var plataforma in _repository.GetAllPlataformas())
            {
                plataformas.Add(_mapper.Map<PlataformaDTO2>(plataforma));
            }
            return plataformas;
        }

        public PlataformaDTO2 GetPlataformaById(int id)
        {
            return _mapper.Map<PlataformaDTO2>(_repository.GetPlataformaById(id));
        }


        public void Update(int id, PlataformaDTO plataforma)
        {
            Plataforma plataformaEntity = _repository.GetPlataformaById(id);
            _repository.Update(Mappers.MapperPlataforma(plataformaEntity, plataforma));
        }
    }
}
