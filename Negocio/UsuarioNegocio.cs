using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Repositorio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        private UsuarioRepositorio _usuarioRepositorio;
        public UsuarioNegocio()
        {
            _usuarioRepositorio = new UsuarioRepositorio();
        }

        // Falta implementar
        public bool CrearUsuario(Usuario usuario)
        {
            return false;
        }

        public List<Usuario> GetUsuarios()
        {
            return _usuarioRepositorio.GetUsuarios();
        }

    }
}
