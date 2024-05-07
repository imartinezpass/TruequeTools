using TruequeTools.Entities;

/*
 
Esta clase define los servicios que ofrece la entidad "Pregunta"

 */

namespace TruequeTools.Services
{
	public interface IServiciosPregunta
	{
        public Task<int> CreatePregunta(Pregunta pregunta); //Create
    }

}