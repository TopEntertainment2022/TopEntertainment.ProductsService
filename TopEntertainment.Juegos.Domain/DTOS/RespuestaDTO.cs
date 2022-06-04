namespace TopEntertainment.Juegos.Domain.DTOS
{
    public class RespuestaDTO
    {
        public RespuestaDTO(string mensaje)
        {
            this.mensaje = mensaje;
        }

        public string mensaje { get; set; }

    }
}
