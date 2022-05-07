using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopEntertainment.Juegos.Domain.DTOS;
using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.Domain.Mapper
{
    public class Mappers
    {
        public static Juego MapperJuego(Juego juegoMapeado,JuegoDTO juego)
        {
            juegoMapeado.NombreProducto = juego.NombreProducto;
            juegoMapeado.Precio = juego.Precio;
            juegoMapeado.Stock = juego.Stock;
            juegoMapeado.Descripcion = juego.Descripcion;
            juegoMapeado.EnOferta = juego.EnOferta;
            juegoMapeado.SoftDelete = juego.SoftDelete;
            juegoMapeado.Video = juego.Video;
            juegoMapeado.PlataformaId = juego.PlataformaId;
            juegoMapeado.ClasificacionId = juego.ClasificacionId;
            return juegoMapeado;
        }
    }
}
