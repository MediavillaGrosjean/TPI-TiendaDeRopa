using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;
using Servicios;

namespace Repositorio
{
    public class UsuarioRepositorio
    {
        private readonly UsuarioDAO _usuarioDAO;

        public UsuarioRepositorio()
        {
            _usuarioDAO = new UsuarioDAO();
        }

        // Devuelve el password inclusive
        /*public Usuario ObtenerUsuarioPorCredenciales(string nombreUsuario, string contraseña)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@NombreUsuario", nombreUsuario),
                new SqlParameter("@Contraseña", contraseña)
            };

            DataTable dt = _usuarioDAO.ObtenerUsuarioPorCredenciales(nombreUsuario, contraseña);

            if (dt.Rows.Count == 0) { return null; }

            DataRow row = dt.Rows[0];

            Usuario usuario = new Usuario()
            {
                ID = (int)row["id_usuario"],
                UserName = row["username"].ToString(),
                Contraseña = row["password"].ToString(),
                Perfil = new Perfil()
                {
                    ID = (int)row["id_perfil"],
                    Rol = row["rol"].ToString()
                }
            };

            return usuario;
        }*/

        public Usuario ValidarUsuario(string nombreUsuario, string contraseña)
        {
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@NombreUsuario", nombreUsuario),
                new SqlParameter("@Contraseña", contraseña)
            };

            DataTable dt = _usuarioDAO.ValidarUsuario(nombreUsuario, contraseña);

            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = dt.Rows[0];

            Usuario usuario = new Usuario()
            {
                ID = (int)row["id_usuario"],
                UserName = row["username"].ToString(),
                Perfil = new Perfil()
                {
                    ID = (int)row["id_perfil"],
                    Rol = row["rol"].ToString()
                }
            };

            return usuario;
        }

        public List<Usuario> GetUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            DataTable dt = _usuarioDAO.GetUsuarios();

            Usuario usuarioAux = new Usuario();
            
            foreach (DataRow fila in dt.Rows)
            {
                usuarioAux = new Usuario();
                usuarioAux.ID = (int)fila["id_usuario"];
                usuarioAux.UserName = fila["username"].ToString();
                usuarioAux.Perfil = new Perfil();
                usuarioAux.Perfil.ID = (int)fila["id_perfil"];
                usuarioAux.Perfil.Rol = fila["rol"].ToString();

                listaUsuarios.Add(usuarioAux);
            }

            return listaUsuarios;
        }
    }
}
