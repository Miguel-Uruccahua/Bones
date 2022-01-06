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
    public partial class Empleado : Form
    {
        ClsEmpleado emp = new ClsEmpleado();
        ClsUsuario usu = new ClsUsuario();
        public Empleado()
        {
            InitializeComponent();
            ListadoEmpleado();
            dataGridView1.Columns["nom_emp"].ReadOnly = true;
            dataGridView1.Columns["direc_emp"].ReadOnly = true;
            dataGridView1.Columns["celular"].ReadOnly = true;
        }
        public void ListadoEmpleado() {
            dataGridView1.DataSource = emp.ListarEmpleado();
            dataGridView1.Columns[0].Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea salir de la ventana?", "Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = emp.BusquedaEmpleado(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    emp.C_nom_emp = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    MessageBox.Show(emp.EliminarEmpleado(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    MessageBox.Show("Seleccione una fila por favor", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            ListadoEmpleado();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormEmpleado empForm = new FormEmpleado();
            empForm.FormClosed += new FormClosedEventHandler(C_formClosed);
            empForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormEmpleado pro = new FormEmpleado();
            if (dataGridView1.SelectedRows.Count > 0)
            {
                pro.textBox1.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
                pro.textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                pro.textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                pro.Editar_Empleado = true;

                dataGridView1.ClearSelection();

                pro.FormClosed += new FormClosedEventHandler(C_formClosed);
                pro.textBox1.Enabled = false;
                pro.ShowDialog();


            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Empleado_Load(object sender, EventArgs e)
        {

        }
        public void C_formClosed(object sender, EventArgs e)
        {
            ListadoEmpleado();
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

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Teal;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Coral;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
        }
    }
}
