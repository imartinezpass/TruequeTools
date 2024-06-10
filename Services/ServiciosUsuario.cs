using Microsoft.EntityFrameworkCore;
using TruequeTools.Data;
using TruequeTools.Entities;

/*
 
Esta clase implementa los servicios que establece la interfaz "InterfazServiciosUsuario"

Utiliza la clase "TruequeToolsDataContext" para comunicarse con la base de datos

Ofrece servicios CRUD y LOCALES para la entidad "Usuario"
 
 */

namespace TruequeTools.Services
{
    public class ServiciosUsuario(TruequeToolsDataContext context) : IServiciosUsuario
    {

        private readonly TruequeToolsDataContext contexto = context;

        public async Task<Usuario> FindEmpleado(int userId)
        {
            var usuario = await contexto.Usuarios.FindAsync(userId);
            return usuario!;
        }

        public async Task<Usuario> OverwriteUsuarioById(Usuario usuario)
        {
            var usuarioExistente = await FindEmpleado(usuario.Id); 

            if (usuarioExistente != null)
            {
                usuarioExistente = usuario;
                await contexto.SaveChangesAsync();

                return usuarioExistente;
            }
            else
            {
                throw new Exception("El usuario no existe.");
            }
        }

        public async Task<List<Usuario>> ReadAllEmpleados()
        {
            return await contexto.Usuarios.Where(x => x.Rol == "Employee").ToListAsync();
        }

        public async Task<List<Usuario>> ReadAllNotDeletedEmpleados()
        {
            return await contexto.Usuarios.Where(x => x.Rol == "Employee" & x.Deleted != true).ToListAsync();

        }

        public async Task<Usuario> ReadUsuarioById(int userId)
        {
            var usuario = await contexto.Usuarios.FindAsync(userId);
            return usuario!;
		}

		//RECIBE UN USUARIO COMO PARAMETRO Y LO AGREGA A LA BASE DE DATOS
		public async Task RegisterUsuario(Usuario usuario)
        {
            contexto.Usuarios.Add(usuario);
            await contexto.SaveChangesAsync();
        }

        public async Task RestablecerContraseña(string email)
        {
            var usuarioExistente = await contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
            if(usuarioExistente != null)
            {
                usuarioExistente.Contraseña = "12345678";
                await contexto.SaveChangesAsync();
            }
        }

        //RECIBE UN CORREO ELECTRONICO Y DEVUELVE SI SE ENCUENTRA REGISTRADO O NO
        public async Task<bool> SeEncuentraRegistrado(string email)
        {
            var usuarioExistente = await contexto.Usuarios.FirstOrDefaultAsync(u => u.Email == email);
            return usuarioExistente != null;
        }

    }

}
