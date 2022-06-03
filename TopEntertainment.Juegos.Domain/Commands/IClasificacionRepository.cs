﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopEntertainment.Juegos.Domain.Entities;

namespace TopEntertainment.Juegos.Domain.Commands
{
    public interface IClasificacionRepository
    {
        List<Clasificacion> GetAllClasificacion();
        Clasificacion GetClasificacionById(int id);
        Clasificacion GetClasificacionByName(string name);
        void Add(Clasificacion clasificacion);
        void Delete(int id);
        void Update(Clasificacion clasificacion);
        public bool ClasificacionIsEmpty(int id);

    }
}