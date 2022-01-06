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
    public partial class Producto : Form
    {
        ClsProducto CL = new ClsProducto();
        public Producto()
        {
            InitializeComponent();
            Listado_Producto();
            btnAgregar.Enabled = false;
            dgvProducto.Columns["Precio"].ReadOnly= true;
            dgvProducto.Columns["cod_cate"].ReadOnly = true;
            dgvProducto.Columns["cod_prov"].ReadOnly = true;
            dgvProducto.Columns["nom_pro"].ReadOnly = true;
            dgvProducto.Columns["stock"].ReadOnly = true;
            dgvProducto.Columns["fecha_venc"].ReadOnly = true;
        }
        public void C_formClosed(object sender, EventArgs e) {
            Listado_Producto();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgvProducto.DataSource = CL.BusquedaProducto(textBox1.Text);
        }
        public void Listado_Producto()
        {
            dgvProducto.DataSource = CL.ListarProducto();
            dgvProducto.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormProducto pro = new FormProducto();
            pro.FormClosed += new FormClosedEventHandler(C_formClosed);
            pro.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea salir de la ventana?", "Clientes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void dgvProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Producto_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProducto.SelectedRows.Count > 0)
                {
                    CL.P_nom_pro = dgvProducto.CurrentRow.Cells[3].Value.ToString();
                    MessageBox.Show(CL.EliminarProducto(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
            Listado_Producto();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormProducto pro = new FormProducto();
            if (dgvProducto.SelectedRows.Count > 0)
            {
                pro.comboBox1.Text = dgvProducto.CurrentRow.Cells[1].Value.ToString();
                pro.comboBox2.Text = dgvProducto.CurrentRow.Cells[2].Value.ToString();
                pro.textBox1.Text = dgvProducto.CurrentRow.Cells[3].Value.ToString();
                pro.textBox2.Text = dgvProducto.CurrentRow.Cells[4].Value.ToString();
                pro.textBox3.Text = dgvProducto.CurrentRow.Cells[5].Value.ToString();
                pro.dateTimePicker1.Text = dgvProducto.CurrentRow.Cells[6].Value.ToString();
                pro.Editar_PRODUCTO = true;

                dgvProducto.ClearSelection();

                pro.FormClosed += new FormClosedEventHandler(C_formClosed);

                pro.ShowDialog();


            }
            else
            {
                MessageBox.Show("Seleccione una fila por favor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Categoria cate = new Categoria();
            cate.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Proveedor prov = new Proveedor();
            prov.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (dgvProducto.SelectedRows.Count == 1)
            {
                Boleta formVentas = Owner as Boleta;
                formVentas.textBox4.Text = dgvProducto.CurrentRow.Cells[3].Value.ToString();
                formVentas.textBox5.Text = dgvProducto.CurrentRow.Cells[4].Value.ToString();
                formVentas.textBox7.Text = dgvProducto.CurrentRow.Cells[5].Value.ToString();

                dgvProducto.ClearSelection();
                Close();
            }
            else
            {
                MessageBox.Show("seleccione una fila porfavor D:", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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

        private void btnAgregar_MouseEnter(object sender, EventArgs e)
        {
            btnAgregar.BackColor = Color.Teal;
        }

        private void btnAgregar_MouseLeave(object sender, EventArgs e)
        {
            btnAgregar.BackColor = Color.Coral;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.Teal;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Coral;
        }
    }
}
