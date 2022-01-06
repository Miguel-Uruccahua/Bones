using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
namespace CapaPresentacion
{
    public partial class Usuario : Form
    {
        ClsUsuario usu = new ClsUsuario();
        Validacion val = new Validacion();
        public Usuario()
        {
            InitializeComponent();
        }
        public void Listado_Empleado() {
            comboBox1.DataSource = usu.ListarEmpleado();
            comboBox1.DisplayMember = "nom_emp";
            comboBox1.ValueMember = "cod_emp";
        }


        private void Usuario_Load(object sender, EventArgs e)
        {
            Listado_Empleado();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                if (val.Validarusu(textBox2.Text) == true && val.Validarusu(textBox3.Text) == true)
                {
                    usu.U_cod_emp = Convert.ToString(comboBox1.SelectedValue);
                    usu.U_nivel_usu = Convert.ToString(comboBox3.SelectedItem);
                    usu.U_id_usu = textBox2.Text;
                    usu.U_pass = textBox3.Text;
                    usu.U_estado = Convert.ToString(comboBox2.SelectedItem);
                    MessageBox.Show(usu.NuevoUsuario(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("DEBES INGRESAR SOLO LETRAS O NUMEROS SIN NINGUN CARACTER ESPECIAL", "!AVISO");
                }
                 }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Teal;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Coral;
        }
    }
}
