using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Perfil : IEntidad
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _rol;
        public string Rol
        {
            get { return _rol; }
            set { _rol = value; }
        }
    }
}
