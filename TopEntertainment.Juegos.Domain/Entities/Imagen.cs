﻿namespace TopEntertainment.Juegos.Domain.Entities
{
    public class Imagen
    {
        public int ImagenId { get; set; }
        public int JuegoId { get; set; }
        public string ImagenUrl { get; set; }

        public virtual Juego Juego { get; set; }
    }
}
