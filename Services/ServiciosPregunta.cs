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

		public async Task<List<Pregunta>> ReadPreguntasByPublicacionId(int id)
		{
			return await contexto.Preguntas.Where(p => p.PublicacionId == id).ToListAsync();
		}
	}
}