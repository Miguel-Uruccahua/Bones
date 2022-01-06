using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
namespace CapaPresentacion
{
    public partial class FormLogin : Form
    {
        ClsUsuario usu = new ClsUsuario();
        public FormLogin()
        {
            InitializeComponent();
        }
        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text=="USUARIO") {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Snow;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "USUARIO";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "CONTRASEÑA")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.Snow;
                txtPass.UseSystemPasswordChar = true;

            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "CONTRASEÑA";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            try {
                if (txtUsuario.Text != "" && txtPass.Text != "")
                {
                    usu.U_id_usu = txtUsuario.Text;
                    usu.U_pass = txtPass.Text;
                    MessageBox.Show(usu.ValidarUsuario(), "AVISO");
                    if (usu.ValidarUsuario() == "Usuario Correcto")
                    {
                        FormMDI MDI = new FormMDI();
                        MDI.lblEmpleado.Text=usu.CapturarUsuario().Rows[0]["nom_emp"].ToString();
                        MDI.lblCargo.Text = usu.CapturarUsuario().Rows[0]["nivel_usu"].ToString();
                        if (usu.CapturarUsuario().Rows[0]["nivel_usu"].ToString() == "Empleado") {
                            MDI.btnEmpleados.Enabled = false;
                            MDI.btnUsuarios.Enabled = false;
                            MDI.btnProveedor.Enabled = false;
                        }
                        MDI.ShowDialog();
                        
                    }
                    else {
                        txtUsuario.Clear();
                         txtPass.Clear();
                    }
                }
                else {
                    MessageBox.Show("DEBE INGRESAR USUARIO Y CONTRASEÑA ","!!AVISO");
                }

            } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void FormLogin_Load_1(object sender, EventArgs e)
        {

        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
