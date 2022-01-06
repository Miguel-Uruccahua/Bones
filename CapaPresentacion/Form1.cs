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
    public partial class Form1 : Form
    {
        ClsCliente CL = new ClsCliente();
        public Form1()
        {
            InitializeComponent();
            Listado_Clientes();
            dgvClientes.Columns["nom_cli"].ReadOnly = true;
            dgvClientes.Columns["direc_cli"].ReadOnly = true;
            dgvClientes.Columns["sexo"].ReadOnly = true;
            dgvClientes.Columns["DNI"].ReadOnly = true;
            dgvClientes.Columns["telefono"].ReadOnly = true;
        }
        private void C_formClosed(object sender, EventArgs e)
        {

            Listado_Clientes();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void Listado_Clientes()
        {
            dgvClientes.DataSource = CL.ListadoClientes();
            dgvClientes.Columns[0].Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgvClientes.DataSource = CL.BusquedaClientes(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 FormCliente = new Form2();
            FormCliente.FormClosed += new FormClosedEventHandler(C_formClosed);
            FormCliente.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvClientes.SelectedRows.Count > 0)
                {
                    CL.C_DNI = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                    MessageBox.Show(CL.EliminarCliente(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
            Listado_Clientes();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea salir de la ventana?", "Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                Form2 FormCliente = new Form2();
                FormCliente.textBox1.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
                FormCliente.textBox2.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();
                FormCliente.comboBox1.Text = dgvClientes.CurrentRow.Cells[3].Value.ToString();
                FormCliente.textBox4.Text = dgvClientes.CurrentRow.Cells[4].Value.ToString();
                FormCliente.textBox5.Text = dgvClientes.CurrentRow.Cells[5].Value.ToString();
                FormCliente.textBox4.Enabled = false;
                FormCliente.EDITAR_CLIENTE = true;

                dgvClientes.ClearSelection();

                FormCliente.FormClosed += new FormClosedEventHandler(C_formClosed);

                FormCliente.ShowDialog();


            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
