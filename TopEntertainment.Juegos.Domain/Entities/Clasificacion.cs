using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopEntertainment.Juegos.Domain.Entities
{
    public class Clasificacion
    {
        public Clasificacion()
        {
            Juegos = new HashSet<Juego>();
        }

        public int ClasificacionId { get; set; }
        public string NombreClasificacion { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Juego> Juegos { get; set; }
    }
}
