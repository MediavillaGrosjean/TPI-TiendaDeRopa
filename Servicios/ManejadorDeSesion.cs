using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace Servicios
{
   public class ManejadorDeSesion
    {
        private static ManejadorDeSesion _instancia;
        private Usuario _sesion;

        private ManejadorDeSesion() { }

        public static ManejadorDeSesion Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ManejadorDeSesion();
                }
                return _instancia;
            }
        }

        public Usuario Sesion
        {
            get { return _sesion; }
            set { _sesion = value; }
        }

        public void LogIn(Usuario usuario)
        {
            _sesion = usuario;
        }

        public void LogOut()
        {
            _sesion = null;
        }

        public bool IsLogged()
        {
            return _sesion != null;
        }
    }
}
