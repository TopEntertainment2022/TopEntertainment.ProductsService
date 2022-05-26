using AutoMapper;
using TopEntertainment.Juegos.Domain.Commands;
using TopEntertainment.Juegos.Domain.DTOS;
using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.Application.Services
{
    public interface IJuegosService
    {
        List<JuegoDTO> GetAllJuegos();
        JuegoDTO GetJuegoById(int id);
        void Add(JuegoDTO2 juego);
        void Delete(int id);
        void Update(int id, JuegoDTO2 juego);

    }
    public class JuegosService : IJuegosService
    {
        private readonly IJuegosRepository _repository;
        private readonly IMapper _mapper;

        public JuegosService(IJuegosRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Add(JuegoDTO2 juego)
        {
            _repository.Add(_mapper.Map<Juego>(juego), juego.Categorias);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<JuegoDTO> GetAllJuegos()
        {
            var mappedJuegos = _mapper.Map<List<JuegoDTO>>(_repository.GetAllJuegos());
            mappedJuegos.ForEach(juego => juego.Categorias = _repository.GetCategoriasByJuegoId(juego.JuegoId));

            return mappedJuegos;
        }

        public JuegoDTO GetJuegoById(int id)
        {
            var juegoDTO = _mapper.Map<JuegoDTO>(_repository.GetJuegoById(id));
            juegoDTO.Categorias = _repository.GetCategoriasByJuegoId(juegoDTO.JuegoId);
            return juegoDTO;
        }

        public void Update(int id, JuegoDTO2 juego)
        {
            var juegoEntity = _mapper.Map<Juego>(juego);
            juegoEntity.JuegoId = id;
            _repository.Update(id, juegoEntity, juego.Categorias);
        }
    }
}
