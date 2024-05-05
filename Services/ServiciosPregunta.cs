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

        //IMPLEMENTACION DE SERVICIOS DE LA ENTIDAD PREGUNTA

    }
}