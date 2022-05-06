using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.Domain.Commands
{
    public interface IJuegosRepository
    {
        List<Juego> GetAllJuegos();
        Juego GetJuegoById(int id);
        Juego GetJuegoByName(string name);
        void Add(Juego juego);
        void Delete(int id);
        void Update(Juego juego);
    }
}
