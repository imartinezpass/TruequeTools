/*
 
Esta clase establece la entidad "Usuario" y sus atributos
 
 */

namespace TruequeTools.Entities
{

    public class Usuario
    {

        //ID UNIVOCO
        public int Id { get; set; }

        //DATOS INGRESADOS POR EL USUARIO
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
        public string? Contraseña { get; set; }
        public DateOnly FechaNacimiento { get; set; }
        public string? Sucursal { get; set; } //ESTO DEBERIA APUNTAR AL ID DE SUCURSAL

        //MEDATDATA
        public string? Rol { get; set; }

    }

}
