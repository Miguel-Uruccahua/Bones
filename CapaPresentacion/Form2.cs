using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaLogica;
namespace CapaPresentacion2
{
    public partial class Form2 : Form

    {
        Validacion val = new Validacion();
        ClsCliente Cus = new ClsCliente();
        public Boolean EDITAR_CLIENTE = false;
        public Form2()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (EDITAR_CLIENTE == false)
                {
                    if (val.ValidarLetras(textBox1.Text) == true && val.ValidarDNI(textBox4.Text) == true && val.ValidarDNI(textBox5.Text) == true)
                    {
                        Cus.C_nom_cli = textBox1.Text;
                        Cus.C_direc_cli = textBox2.Text;
                        Cus.C_sexo = comboBox1.SelectedItem.ToString();
                        Cus.C_DNI = textBox4.Text;
                        Cus.C_telefono = textBox5.Text;


                        MessageBox.Show(Cus.NuevoCliente(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else {
                        MessageBox.Show("DEBES COMPLETAR CORRECTAMENTE LOS DATOS SIN NINGUN CARACTER ESPECIAL \n Y LLENANDO SOLO 8 DIGITOS EN DNI Y TELEFONO", "!!aviso");
                    }
                }
                if (EDITAR_CLIENTE == true) {
                    if (val.ValidarLetras(textBox1.Text) == true && val.ValidarLetras(textBox2.Text) == true && val.ValidarDNI(textBox4.Text) == true && val.ValidarDNI(textBox5.Text) == true)
                    {
                        Cus.C_nom_cli = textBox1.Text;
                        Cus.C_direc_cli = textBox2.Text;
                        Cus.C_sexo = comboBox1.SelectedItem.ToString();
                        Cus.C_DNI = textBox4.Text;
                        Cus.C_telefono = textBox5.Text;

                        MessageBox.Show(Cus.EditarCliente(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        EDITAR_CLIENTE = false;
                    }
                    else
                    {
                        MessageBox.Show("DEBES COMPLETAR CORRECTAMENTE LOS DATOS SIN NINGUN CARACTER ESPECIAL \n Y LLENANDO SOLO 8 DIGITOS EN DNI Y TELEFONO", "!!aviso");
                    }

                }
                textBox4.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
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
