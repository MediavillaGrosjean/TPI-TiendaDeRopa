using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public interface IUsuarioVistaModelo
    {
        string UserName { get; }
        string RolPerfil { get; }
    }
}
