namespace TopEntertainment.Juegos.Domain.DTOS
{
    public class JuegoDTO2
    {
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public bool EnOferta { get; set; }
        public string Video { get; set; }
        public int PlataformaId { get; set; }
        public int ClasificacionId { get; set; }
        public List<int>? Categorias { get; set; }
        public List<string>? Imagenes { get; set; }
    }
}
