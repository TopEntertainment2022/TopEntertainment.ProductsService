using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopEntertainment.Juegos.Domain.Commands;
using TopEntertainment.Juegos.Domain.DTOS;
using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.Application.Services
{
    public interface IJuegosService
    {
        List<Juego> GetAllJuegos();
        Juego GetJuegoById(int id);
        Juego GetJuegoByName(string name);
        void Add(JuegoDTO juego);
        void Delete(int id);
        void Update(Juego juego);

    }
    public class JuegosService : IJuegosService
    {
        private readonly IJuegosRepository _repository;

        public JuegosService(IJuegosRepository repository)
        {
            _repository = repository;
        }

        public void Add(JuegoDTO juego)
        {
            Juego juegoMapeado = new Juego();

            juegoMapeado.NombreProducto = juego.NombreProducto;
            juegoMapeado.Precio = juego.Precio; 
            juegoMapeado.Stock = juego.Stock;
            juegoMapeado.Descripcion = juego.Descripcion;
            juegoMapeado.EnOferta = juego.EnOferta;
            juegoMapeado.SoftDelete = juego.SoftDelete;
            juegoMapeado.Video = juego.Video;
            juegoMapeado.PlataformaId = juego.PlataformaId;
            juegoMapeado.ClasificacionId = juego.ClasificacionId;








            _repository.Add(juegoMapeado);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Juego> GetAllJuegos()
        {
            return _repository.GetAllJuegos();
        }

        public Juego GetJuegoById(int id)
        {
            return _repository.GetJuegoById(id);
        }

        public Juego GetJuegoByName(string name)
        {
            return _repository.GetJuegoByName(name);
        }

        public void Update(Juego juego)
        {
            throw new NotImplementedException();
        }
    }
}
