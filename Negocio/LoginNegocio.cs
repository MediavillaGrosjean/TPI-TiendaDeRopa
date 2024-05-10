using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Repositorio;
using Servicios;

namespace Negocio
{
    public class LoginNegocio
    {
        private UsuarioRepositorio _usuarioRepositorio;

        public LoginNegocio()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        public void LogOut()
        {
            ManejadorDeSesion.Instancia.LogOut();
        }

        public void LogIn(string username, string password)
        {
            if (String.IsNullOrWhiteSpace(username) || String.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("El nombre de usuario y la contraseña no pueden estar vacíos.");
            }
            try
            {
                Usuario usuario = _usuarioRepositorio.ValidarUsuario(username, password);

                if (usuario == null) throw new Exception("Usuario o contraseña incorrecta");

                ManejadorDeSesion.Instancia.LogIn(usuario);

            }
            catch
            {
                throw;
            }
        }
    }
}
