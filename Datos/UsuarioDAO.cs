﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class UsuarioDAO
    {
        private ManejadorStoreProcedure _storeProcedure;

        public UsuarioDAO()
        {
            _storeProcedure = new ManejadorStoreProcedure();
        }

        public DataTable ObtenerUsuarioPorCredenciales(string nombreUsuario, string contraseña)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@NombreUsuario", nombreUsuario),
                new SqlParameter("@Contraseña", contraseña)
            };

            return _storeProcedure.LeerPorStoreProcedure("ObtenerUsuarioPorCredenciales", parametros);
        }

        public DataTable ValidarUsuario(string nombreUsuario, string contraseña)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@NombreUsuario", nombreUsuario),
                new SqlParameter("@Contraseña", contraseña)
            };

            return _storeProcedure.LeerPorStoreProcedure("sp_validar_usuarios", parametros);
        }

        public DataTable GetUsuarios()
        {
            return _storeProcedure.LeerPorStoreProcedure("sp_listar_usuarios");
        }

    }
}
