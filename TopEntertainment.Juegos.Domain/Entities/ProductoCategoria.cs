namespace TopEntertainment.Juegos.Domain.Entities
{
    public class ProductoCategoria
    {
        public int Id { get; set; }
        public int JuegoId { get; set; }
        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }
        public virtual Juego Juego { get; set; }

        public ProductoCategoria(int juegoID, int categoriaId)
        {
            JuegoId = juegoID;
            CategoriaId = categoriaId;
        }

        public ProductoCategoria()
        {
        }
    }
}
