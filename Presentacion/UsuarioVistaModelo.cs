using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Presentacion
{
    public class UsuarioVistaModelo : IUsuarioVistaModelo
    {
        private Usuario _usuario;

        public UsuarioVistaModelo(Usuario usuario)
        {
            _usuario = usuario;
        }

        public string UserName => _usuario.UserName;

        public string RolPerfil => _usuario.Perfil?.Rol ?? string.Empty;
    }
}
