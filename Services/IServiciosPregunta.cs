using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Pregunta"

 */

namespace TruequeTools.Services
{
	public interface IServiciosPregunta
	{
		public Task<List<Pregunta>> ReadPreguntasByPublicacionId(int id);
		public Task CreatePregunta(Pregunta pregunta);
		public Task ResponderPregunta(int preguntaId, string respuesta);
        public Task<List<Pregunta>> ReadAllPreguntasRealizadasByUser(int userId);
    }
}