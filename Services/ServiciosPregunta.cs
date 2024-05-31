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

		public async Task CreatePregunta(Pregunta pregunta)
		{	
			contexto.Preguntas.Add(pregunta);
			await contexto.SaveChangesAsync();
		}

        //DEVUELVE UNA LISTA CON TODAS LAS PREGUNTAS DE LA PUBLICACION QUE SE PASA COMO PARAMETRO
        public async Task<List<Pregunta>> ReadPreguntasByPublicacionId(int id)
		{
			return await contexto.Preguntas.Where(p => p.PublicacionId == id).ToListAsync();
		}

        public async Task<List<Pregunta>> ReadAllPreguntasRealizadasByUser(int userId)
        {
            var preguntas = await contexto.Preguntas.Where(p => p.UsuarioId == userId).ToListAsync();
			List<Pregunta> preguntasFiltered = new();
			foreach (var pregunta in preguntas)
			{
                await context.Entry(pregunta).Reference(p => p.Publicacion).LoadAsync();
				if(pregunta.Publicacion!.Deleted == false)
				{
					preguntasFiltered.Add(pregunta);
				}
            }
			return preguntasFiltered;
        }

		public async Task ResponderPregunta(int preguntaId, string respuesta)
		{
			var pregunta = await contexto.Preguntas.FirstOrDefaultAsync(p => p.Id == preguntaId);
			pregunta!.Respuesta = respuesta;
			await contexto.SaveChangesAsync();
		}
	}

}
