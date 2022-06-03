using AutoMapper;
using TopEntertainment.Juegos.Domain.Commands;
using TopEntertainment.Juegos.Domain.DTOS;
using TopEntertainment.Juegos.Domain.Entities;
using TopEntertainment.Juegos.Domain.Mapper;

namespace TopEntertainment.Juegos.Application.Services
{
    public interface IClasificacionService
    {
        List<ClasificacionDTO2> GetAllClasificacion();
        ClasificacionDTO2 GetClasificacionById(int id);
        void Add(ClasificacionDTO clasificacion);
        void Delete(int id);
        void Update(int id, ClasificacionDTO clasificacion);
        public bool ClasificacionIsEmpty(int id);

    }
    public class ClasificacionService : IClasificacionService
    {
        private readonly IClasificacionRepository _repository;
        private readonly IMapper _mapper;

        public ClasificacionService(IClasificacionRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(ClasificacionDTO clasificacion)
        {

            _repository.Add(_mapper.Map<Clasificacion>(clasificacion));
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<ClasificacionDTO2> GetAllClasificacion()
        {
            var clasificacion = new List<ClasificacionDTO2>();
            foreach (var clasificaciones in _repository.GetAllClasificacion())
            {
                clasificacion.Add(_mapper.Map<ClasificacionDTO2>(clasificaciones));
            }
            return clasificacion;
        }

        public ClasificacionDTO2 GetClasificacionById(int id)
        {
            return _mapper.Map<ClasificacionDTO2>(_repository.GetClasificacionById(id));
        }


        public void Update(int id, ClasificacionDTO clasificacion)

        {
            Clasificacion clasificacionEntity = _repository.GetClasificacionById(id);
            _repository.Update(Mappers.MapperClasificacion(clasificacionEntity, clasificacion));
        }

        public bool ClasificacionIsEmpty(int id)
        {
            return _repository.ClasificacionIsEmpty(id);
        }
    }

}
