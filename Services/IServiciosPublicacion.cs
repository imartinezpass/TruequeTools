﻿using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Publicacion"

 */

namespace TruequeTools.Services
{
    public interface IServiciosPublicacion
    {
        public Task<int> CreatePublicacion(Publicacion publicacion); //Create

    }
}