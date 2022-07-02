using AutoMapper;
using TopEntertainment.Juegos.Domain.DTOS;
using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.Presentation
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Juego, JuegoDTO>();
            CreateMap<JuegoDTO, Juego>();
            CreateMap<JuegoDTO2, Juego>();
            CreateMap<Categoria, CategoriaDTO>();
            CreateMap<PlataformaDTO, Plataforma>();
            CreateMap<PlataformaDTO2, Plataforma>();
            CreateMap<Plataforma, PlataformaDTO2>();

            CreateMap<ClasificacionDTO, Clasificacion>();
            CreateMap<ClasificacionDTO2, Clasificacion>();
            CreateMap<Clasificacion, ClasificacionDTO2>();
        }
    }
}
