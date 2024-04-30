/*
 
Esta clase establece la entidad "Comentario" y sus atributos
 
 */

namespace TruequeTools.Entities
{

    public class Comentario
    {

        //ID UNIVOCO
        public int Id { get; set; }

        //DATOS INGRESADOS POR EL USUARIO
        public string? Texto { get; set; }
        public int? RespuestaId { get; set; }

    }

}

