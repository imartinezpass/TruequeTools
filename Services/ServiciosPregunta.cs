using TruequeTools.Data;
using Microsoft.EntityFrameworkCore;
using TruequeTools.Entities;

/*
 
Esta clase implementa los servicios que establece la interfaz "InterfazServiciosPregunta"

Utiliza la clase "TruequeToolsDataContext" para comunicarse con la base de datos

Ofrece servicios CRUD y LOCALES para la entidad "Pregunta"
 
 */

namespace TruequeTools.Services
{
	public class ServiciosPregunta(TruequeToolsDataContext context) : IServiciosPregunta
	{
            private readonly TruequeToolsDataContext contexto = context;

            //RECIBE UN PRODUCTO COMO PARAMETRO Y LO AGREGA A LA BASE DE DATOS
            public async Task CreatePregunta(Pregunta pregunta)
            {
                contexto.Pregunta.Add(pregunta);
                await contexto.SaveChangesAsync();
                return pregunta;
            }
    }
}