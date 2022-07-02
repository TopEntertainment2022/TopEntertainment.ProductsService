using TopEntertainment.Juegos.Domain.Commands;
using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.AccessData.Commands
{
    public class CategoryRepository : ICategoriaRepository
    {

        private readonly JuegosContext _context;

        public CategoryRepository(JuegosContext context)
        {
            _context = context;
        }


       

        public List<Categoria> GetAllCategorias()
        {
            return _context.Categoria.ToList();
        }

       

    }
}
