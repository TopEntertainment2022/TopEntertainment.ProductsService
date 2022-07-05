using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.Domain.DTOS
{
    public class JuegoDTO
    {
        public int JuegoId { get; set; }
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool EnOferta { get; set; }
        public string Video { get; set; }
        public PlataformaDTO2 Plataforma { get; set; }
        public ClasificacionDTO2 Clasificacion { get; set; }
        public List<Categoria> Categorias { get; set; }
        public List<string> Imagenes { get; set; }

    }



}
