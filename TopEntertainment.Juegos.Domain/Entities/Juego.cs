using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopEntertainment.Juegos.Domain.Entities
{
    public class Juego
    {
        public int JuegoId { get; set; }
        public int PlataformaId { get; set; }
        public int ClasificacionId { get; set; }
        public string NombreProducto { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Descripcion { get; set; }
        public bool EnOferta { get; set; }
        public bool SoftDelete { get; set; }
        public string Video { get; set; }

        public virtual Clasificacion Clasificacion { get; set; }
        public virtual Plataforma Plataforma { get; set; }
    }
}
