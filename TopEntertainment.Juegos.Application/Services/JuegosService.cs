using AutoMapper;
using TopEntertainment.Juegos.Domain.Commands;
using TopEntertainment.Juegos.Domain.DTOS;
using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.Application.Services
{
    public interface IJuegosService
    {
        List<JuegoDTO> GetAllJuegos(int? categoria = null, int? clasificacion = null, int? plataforma = null, string? descripcion = null, int? precioMinimo = null, int? precioMaximo = null);
        JuegoDTO GetJuegoById(int id);
        void Add(JuegoDTO2 juego);
        void Delete(int id);
        void Update(int id, JuegoDTO2 juego);
        List<JuegoDTO> GetJuegosByPlataformaId(int id);
        List<JuegoDTO> GetJuegosByCategoriaId(int id);
        List<JuegoDTO> GetJuegosByClasificacionId(int id);
        public bool ValidarPlataforma(int id);
        public bool ValidarClasificacion(int id);

        public bool ValidarCategorias(List<int>? lista);
        public bool ValidarCategoria(int id);

        public bool ValidarJuego(int id);

        public List<JuegoDTO> GetOfertas(int top);

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
            _repository.Add(_mapper.Map<Juego>(juego), juego.Categorias, juego.Imagenes);
        }

        public void Update(int id, JuegoDTO2 juego)
        {
            var juegoEntity = _mapper.Map<Juego>(juego);
            juegoEntity.JuegoId = id;
            _repository.Update(id, juegoEntity, juego.Categorias, juego.Imagenes);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<JuegoDTO> GetAllJuegos(int? categoria = null, int? clasificacion = null, int? plataforma = null, string? descripcion = null, int? precioMinimo = null, int? precioMaximo = null)
        {
            var mappedJuegos = _mapper.Map<List<JuegoDTO>>(_repository.GetAllJuegos(categoria, clasificacion, plataforma, descripcion, precioMinimo, precioMaximo));
            mappedJuegos.ForEach(juego => juego.Categorias = _repository.GetCategoriasByJuegoId(juego.JuegoId));
            mappedJuegos.ForEach(juego => juego.Imagenes = _repository.GetImagenesByJuegoId(juego.JuegoId));
            return mappedJuegos;
        }

        public JuegoDTO GetJuegoById(int id)
        {
            var juegoDTO = _mapper.Map<JuegoDTO>(_repository.GetJuegoById(id));
            juegoDTO.Categorias = _repository.GetCategoriasByJuegoId(juegoDTO.JuegoId);
            juegoDTO.Imagenes = _repository.GetImagenesByJuegoId(juegoDTO.JuegoId);
            return juegoDTO;
        }

        public List<JuegoDTO> GetJuegosByPlataformaId(int id)
        {
            var mappedJuegos = _mapper.Map<List<JuegoDTO>>(_repository.GetJuegosByPlataformaId(id));
            mappedJuegos.ForEach(juego => juego.Categorias = _repository.GetCategoriasByJuegoId(juego.JuegoId));
            mappedJuegos.ForEach(juego => juego.Imagenes = _repository.GetImagenesByJuegoId(juego.JuegoId));
            return mappedJuegos;
        }

        public List<JuegoDTO> GetJuegosByCategoriaId(int id)
        {
            var mappedJuegos = _mapper.Map<List<JuegoDTO>>(_repository.GetJuegosByCategoriaId(id));
            mappedJuegos.ForEach(juego => juego.Categorias = _repository.GetCategoriasByJuegoId(juego.JuegoId));
            mappedJuegos.ForEach(juego => juego.Imagenes = _repository.GetImagenesByJuegoId(juego.JuegoId));
            return mappedJuegos;
        }

        public List<JuegoDTO> GetJuegosByClasificacionId(int id)
        {
            var mappedJuegos = _mapper.Map<List<JuegoDTO>>(_repository.GetJuegosByClasificacionId(id));
            mappedJuegos.ForEach(juego => juego.Categorias = _repository.GetCategoriasByJuegoId(juego.JuegoId));
            mappedJuegos.ForEach(juego => juego.Imagenes = _repository.GetImagenesByJuegoId(juego.JuegoId));
            return mappedJuegos;
        }

        public bool ValidarPlataforma(int id)
        {
            return _repository.ValidarPlataforma(id);
        }

        public bool ValidarClasificacion(int id)
        {
            return _repository.ValidarClasificacion(id);
        }

        public bool ValidarCategorias(List<int>? lista)
        {
            foreach (int c in lista)
            {
                if (!_repository.ValidarCategoria(c)) return false;
            }
            return true;
        }

        public bool ValidarCategoria(int id)
        {
            return _repository.ValidarCategoria(id);
        }

        public bool ValidarJuego(int id)
        {
            return _repository.ValidarJuego(id);
        }

        public List<JuegoDTO> GetOfertas(int top)
        {
            var mappedJuegos = _mapper.Map<List<JuegoDTO>>(_repository.GetOfertas(top));
            mappedJuegos.ForEach(juego => juego.Categorias = _repository.GetCategoriasByJuegoId(juego.JuegoId));
            mappedJuegos.ForEach(juego => juego.Imagenes = _repository.GetImagenesByJuegoId(juego.JuegoId));
            return mappedJuegos;
        }
    }
}
