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
    public partial class FormEmpleado : Form
    {
        ClsEmpleado em = new ClsEmpleado();
        public bool Editar_Empleado = false;
        Validacion val = new Validacion();
        public FormEmpleado()
        {
            InitializeComponent();
        }

        private void FormEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Editar_Empleado == false)
                {
                    if (val.ValidarLetras(textBox1.Text) == true && val.ValidarDNI(textBox3.Text) == true)
                    {
                        em.C_nom_emp = textBox1.Text;
                        em.C_direc_emp = textBox2.Text;
                        em.C_celular = textBox3.Text;


                        MessageBox.Show(em.NuevoEmpleado(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else {
                        MessageBox.Show("DEBES INGRESAR SOLO LETRAS SIN CARACTERES ESPECIALES Y SOLO 8 DIGITOS EN EL TELEFONO","!AVISO");
                    }
                }
                if (Editar_Empleado == true)
                {
                    if (val.ValidarLetras(textBox1.Text) == true && val.ValidarLetras(textBox2.Text) == true && val.ValidarDNI(textBox3.Text) == true)
                    {
                        em.C_nom_emp = textBox1.Text;
                        em.C_direc_emp = textBox2.Text;
                        em.C_celular = textBox3.Text;

                        MessageBox.Show(em.EditarEmpleado(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Editar_Empleado = false;
                    }
                    else
                    {
                        MessageBox.Show("DEBES INGRESAR SOLO LETRAS SIN CARACTERES ESPECIALES Y SOLO 8 DIGITOS EN EL TELEFONO", "!AVISO");
                    }
                }
                textBox1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Teal;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Coral;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Teal;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Coral;
        }
    }
}
