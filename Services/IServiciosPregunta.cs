using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Pregunta"

 */

namespace TruequeTools.Services
{
	public interface IServiciosPregunta
	{
		public Task<List<Pregunta>> ReadPreguntasByPublicacionId(int id); //Read
	}

}