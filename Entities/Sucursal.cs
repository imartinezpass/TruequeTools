/*
 
Esta clase establece la entidad "Sucursal" y sus atributos
 
 */

namespace TruequeTools.Entities
{

    public class Sucursal
    {

        //ID UNIVOCO
        public int Id { get; set; }

        //DATOS INGRESADOS POR EL USUARIO
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Localidad { get; set; }

    }

}
