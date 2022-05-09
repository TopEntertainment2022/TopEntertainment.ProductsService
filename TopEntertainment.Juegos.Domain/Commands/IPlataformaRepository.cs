using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.Domain.Commands
{
    public interface IPlataformaRepository
    {
        List<Plataforma> GetAllPlataformas();
        Plataforma GetPlataformaById(int id);
        Plataforma GetPlataformaByName(string name);

        void Add(Plataforma plataforma);
        void Delete(int id);
        void Update(Plataforma plataforma);

    }
}
