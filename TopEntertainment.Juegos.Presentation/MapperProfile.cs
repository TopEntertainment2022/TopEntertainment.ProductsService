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
            //CreateMap<Origen, Destino>();
            CreateMap<PlataformaDTO, Plataforma>();
            CreateMap<PlataformaDTO2, Plataforma>();
            CreateMap<Plataforma, PlataformaDTO2>();
        }
    }
}
