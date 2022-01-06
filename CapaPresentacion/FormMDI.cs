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
using CapaPresentacion2;
namespace CapaPresentacion
{
    public partial class FormMDI : Form
    {
        public FormMDI()
        {
            InitializeComponent();
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormMDI_Load(object sender, EventArgs e)
        {
            timer1_Tick(null, e);
            /*if (Program.IdCargo == 3)
            {
                btnEmpleados.Enabled = false;
                lblCargo.Text = "Area de Ventas";
            
            }
            lblEmpleado.Text = Program.NombreEmpleadoLogueado;
            if (Program.IdCargo == 1)
            {
                lblCargo.Text = "Administrador";
                lblEmpleado.Text = "Juan Algeria Torres";
            }*/
        }

        #region FUNCIONALIDADES DEL FORMULARIO
        //RESIZE METODO PARA REDIMENCIONAR/CAMBIAR TAMAÑO A FORMULARIO EN TIEMPO DE EJECUCION ----------------------------------------------------------
        private int tolerance = 12;
        private const int WM_NCHITTEST = 132;
        private const int HTBOTTOMRIGHT = 17;
        private Rectangle sizeGripRectangle;

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    var hitPoint = this.PointToClient(new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16));
                    if (sizeGripRectangle.Contains(hitPoint))
                        m.Result = new IntPtr(HTBOTTOMRIGHT);
                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }
        //----------------DIBUJAR RECTANGULO / EXCLUIR ESQUINA PANEL 
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            var region = new Region(new Rectangle(0, 0, this.ClientRectangle.Width, this.ClientRectangle.Height));

            sizeGripRectangle = new Rectangle(this.ClientRectangle.Width - tolerance, this.ClientRectangle.Height - tolerance, tolerance, tolerance);

            region.Exclude(sizeGripRectangle);
            this.panelContenedor.Region = region;
            this.Invalidate();
        }
        //----------------COLOR Y GRIP DE RECTANGULO INFERIOR
        protected override void OnPaint(PaintEventArgs e)
        {
            SolidBrush blueBrush = new SolidBrush(Color.FromArgb(244, 244, 244));
            e.Graphics.FillRectangle(blueBrush, sizeGripRectangle);

            base.OnPaint(e);
            ControlPaint.DrawSizeGrip(e.Graphics, Color.Transparent , sizeGripRectangle);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //CAPTURAR LOS TAMAÑOS ORIGINALES
        int lx, ly;
        int sw , sh;

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            btnMaximizar.Visible = true;
            btnRestaurar.Visible = false;
            this.Size = new Size(sw,sh);
            this.Location = new Point(lx,ly);
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void panelBarraTitulo_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //METODO PARA ARRASTRAR EL FORMULARIO---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Form1>();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario < Producto>();

        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Boleta>();

        }

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss ");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Empleado>();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Proveedor>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Usuario>();
        }

        private void lblHora_Click(object sender, EventArgs e)
        {

        }

        private void btnClientes_MouseEnter(object sender, EventArgs e)
        {
            btnClientes.BackColor = Color.Blue;
        }

        private void btnClientes_MouseLeave(object sender, EventArgs e)
        {
            btnClientes.BackColor = Color.Teal;
        }

        private void btnProductos_MouseLeave(object sender, EventArgs e)
        {
            btnProductos.BackColor = Color.Teal;
        }

        private void btnVentas_MouseLeave(object sender, EventArgs e)
        {
            btnVentas.BackColor = Color.Teal;
        }

        private void btnProductos_MouseEnter(object sender, EventArgs e)
        {
            btnProductos.BackColor = Color.Blue;
        }

        private void btnVentas_MouseEnter(object sender, EventArgs e)
        {
            btnVentas.BackColor = Color.Blue;
        }

        #endregion
        //METODO PARA ABRIR FORMULARIOS DESDE EL PANEL DE FORMULARIOS

        private void AbrirFormulario<MiForm>() where MiForm : Form, new() {

            Form formulario;
            formulario = panelFormularios.Controls.OfType<MiForm>().FirstOrDefault(); // BUSCA EN LA COLECCION EL FOMULARIO
            
            //SI EL FORMULARIO Y/O INSTANCIA NO EXISTE
            if (formulario == null)
            {
                formulario = new MiForm();
                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                panelFormularios.Controls.Add(formulario);
                panelFormularios.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
                formulario.FormClosed += new FormClosedEventHandler(CerrarFormulario);
            }
            // SI EL FORMULARIO  Y/O INSTANCIA YA EXISTE
            else
            {
                formulario.BringToFront();

            }
        }

        private void CerrarFormulario(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms["frmLISTADOCLIENTE"] == null)
                btnClientes.BackColor = Color.FromArgb(137, 0, 28);
            if (Application.OpenForms["frmLISTADOPRODUCTOS"] == null)
                btnProductos.BackColor = Color.FromArgb(137, 0, 28);
            if (Application.OpenForms["FormComprobante"] == null)
                btnVentas.BackColor = Color.FromArgb(137, 0, 28);
            if (Application.OpenForms["FormListaEmpleado"] == null)
                btnEmpleados.BackColor = Color.FromArgb(137, 0, 28);

        }

    }
}
