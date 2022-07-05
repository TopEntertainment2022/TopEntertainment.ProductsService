using TopEntertainment.Juegos.Domain.DTOS;
using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.Domain.Mapper
{
    public class Mappers
    {

        public static Juego MapperJuego(Juego JuegoEntity, JuegoDTO juego)
        {
            JuegoEntity.NombreProducto = juego.NombreProducto;
            JuegoEntity.Precio = juego.Precio;
            JuegoEntity.Stock = juego.Stock;
            JuegoEntity.Descripcion = juego.Descripcion;
            JuegoEntity.EnOferta = juego.EnOferta;
            JuegoEntity.Video = juego.Video;
            return JuegoEntity;
        }


        public static Plataforma MapperPlataforma(Plataforma PlataformaEntity, PlataformaDTO plataforma)
        {
            PlataformaEntity.Descripcion = plataforma.Descripcion;
            PlataformaEntity.NombrePlataforma = plataforma.NombrePlataforma;
            return PlataformaEntity;
        }



        public static Clasificacion MapperClasificacion(Clasificacion clasificacionEntity, ClasificacionDTO clasificacion)
        {
            clasificacionEntity.Descripcion = clasificacion.Descripcion;
            clasificacionEntity.NombreClasificacion = clasificacion.NombreClasificacion;
            return clasificacionEntity;
        }
    }
}
