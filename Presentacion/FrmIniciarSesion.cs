using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocio;
using Servicios;

namespace Presentacion
{
    public partial class FrmIniciarSesion : Form
    {
        private LoginNegocio _login;
        private UsuarioNegocio _usuarioNegocio;

        public FrmIniciarSesion()
        {
            InitializeComponent();
            pnlSesionActiva.Visible = false;
            dgvListadoUsuarios.Visible = false;
            _usuarioNegocio = new UsuarioNegocio();
            _login = new LoginNegocio();
        }

        private void BtnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                _login.LogIn(txtUsername.Text, txtPassword.Text);
                ValidarSesion();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo un error al iniciar sesión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManejadorDeSesion.Instancia.LogOut();
            ValidarSesion();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VerListaDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            List<Usuario> usuarios = _usuarioNegocio.GetUsuarios();
            List<IUsuarioVistaModelo> UsuarioVistaModelo = new List<IUsuarioVistaModelo>();

            foreach (Usuario usuario in usuarios)
            {
                UsuarioVistaModelo.Add(new UsuarioVistaModelo(usuario));
            }

            dgvListadoUsuarios.DataSource = UsuarioVistaModelo;
            
            dgvListadoUsuarios.Columns["UserName"].HeaderText = "    Usuario";
            dgvListadoUsuarios.Columns["RolPerfil"].HeaderText = "    Puesto";

            dgvListadoUsuarios.Visible = true;
        }

        private void ValidarSesion()
        {
            if (ManejadorDeSesion.Instancia.IsLogged())
            {
                string nombre = ManejadorDeSesion.Instancia.Sesion.UserName;
                string perfil = ManejadorDeSesion.Instancia.Sesion.Perfil.Rol;
                pnlSesionActiva.Visible = true;
                lblNameUserSesion.Text = $"  Usuario: {nombre}  ";
                lblRoleUserSesion.Text = $"  Perfil: {perfil}  ";
            }
            else
            {
                pnlSesionActiva.Visible = false;
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;

                dgvListadoUsuarios.DataSource = null;
                dgvListadoUsuarios.Visible = false;

                this.SelectNextControl(this, true, true, true, true);
            }
        }
    }
}
