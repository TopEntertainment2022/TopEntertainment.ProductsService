using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopEntertainment.Juegos.Domain.Entities
{
    public class Plataforma
    {
        public Plataforma()
        {
            Juegos = new HashSet<Juego>();
        }

        public int PlataformaId { get; set; }
        public string NombrePlataforma { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Juego> Juegos { get; set; }
    }
}
