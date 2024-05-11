using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario : IEntidad
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nombreUsuario;

        public string UserName
        {
            get { return _nombreUsuario; }
            set { _nombreUsuario = value; }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private Perfil _perfil;

        public Perfil Perfil
        {
            get { return _perfil; }
            set { _perfil = value; }
        }
    }
}
