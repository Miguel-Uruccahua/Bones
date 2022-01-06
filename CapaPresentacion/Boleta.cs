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
using CapaPresentacion2;
namespace CapaPresentacion
{
    public partial class Boleta : Form
    {
        ClsCliente cli = new ClsCliente();
        ClsProducto pro = new ClsProducto();
        Venta venta = new Venta();
        Detalles deta = new Detalles();
        Validacion val = new Validacion();
        public Boleta()
        {
            InitializeComponent();
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox7.Enabled = false;
            dateTimePicker1.Enabled = false;
            dataGridView1.Columns["cantidad"].ReadOnly = true;
            dataGridView1.Columns["descripcion"].ReadOnly = true;
            dataGridView1.Columns["precio_unitario"].ReadOnly = true;
            dataGridView1.Columns["importe"].ReadOnly = true;


        }

        private void Boleta_Load(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != Convert.ToChar(Keys.Back) && (e.KeyChar != Convert.ToChar(Keys.Enter)))&&val.ValidarDNI(textBox1.Text)==true)
            {
                MessageBox.Show("SOLO SE PERMITEN NUMEROS ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (cli.BusquedaDNI(textBox1.Text).Rows.Count == 1)
                {
                    textBox2.Text = cli.BusquedaDNI(textBox1.Text).Rows[0]["nom_cli"].ToString();
                    textBox3.Text = cli.BusquedaDNI(textBox1.Text).Rows[0]["direc_cli"].ToString();

                }

                else
                {
                    Form2 fr = new Form2();
                    fr.ShowDialog();
                    textBox1.Clear();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                Producto pro = new Producto();
                pro.textBox1.Focus();
                pro.btnAgregar.Enabled = true;
                //Importante
                AddOwnedForm(pro);
                pro.ShowDialog();
                pro.btnAgregar.Enabled = false;
            }
            else
            {
                MessageBox.Show("SELECCIONE UN Cliente PORFAVORE D:", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea salir de la aplicación?", "Clientes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != Convert.ToChar(Keys.Back) && (e.KeyChar != Convert.ToChar(Keys.Enter))))
            {
                MessageBox.Show("SOLO SE PERMITEN NUMEROS ", "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Handled = true;
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() != "")
            {
                if (textBox6.Text.Trim() != "" && Convert.ToInt32(textBox6.Text) > 0&& Convert.ToInt32(textBox6.Text)< Convert.ToInt32(textBox7.Text))
                {
                    double subTotal = Convert.ToDouble(textBox6.Text) * Convert.ToDouble(textBox5.Text);
                    dataGridView1.Rows.Add(1, 1, textBox6.Text, textBox4.Text, textBox5.Text, Convert.ToString(subTotal));
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    subTotal = 0;
                    button2.Focus();

                }
                else
                {
                    MessageBox.Show("Ingrese una cantidad y/o la cantidad es mayor al stock", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {

                MessageBox.Show("Porfavor Seleccione un producto", "AVISO!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            MostrarTotal();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
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
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }
        public double CalcularTotal() {
            double total=0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++) {
                total += Double.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString());
            }
            return total;
        }
        public void MostrarTotal() {
            label15.Text = CalcularTotal().ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                venta.V_cod_emp = "1";
                venta.V_cod_cli = cli.BusquedaDNI(textBox1.Text).Rows[0]["cod_cli"].ToString();
                venta.V_fecha = dateTimePicker1.Text;
                venta.V_tipo_comprovante = "BOLETA";
                venta.V_total = CalcularTotal().ToString();
                MessageBox.Show(venta.NuevaVenta(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                for (int r = 0; r < dataGridView1.Rows.Count; r++) {
                    deta.D_cod_pedido = venta.UltimaVenta().Rows[0]["final"].ToString();
                    deta.D_cod_pro = pro.BusquedaProducto(dataGridView1.Rows[r].Cells[3].Value.ToString()).Rows[0]["cod_pro"].ToString();
                    deta.D_cantidad = dataGridView1.Rows[r].Cells[2].Value.ToString();
                    deta.D_precio_unitario = dataGridView1.Rows[r].Cells[4].Value.ToString();
                    deta.D_importe = dataGridView1.Rows[r].Cells[5].Value.ToString();
                    deta.NuevoDetalle();
                }
                dataGridView1.Rows.Clear();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        
            else {
                MessageBox.Show("INGRESE ALGUN PRODUCTO PORFAVOR", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
          
        }

        private void button7_Click_2(object sender, EventArgs e)
        {
            textBox5.Text = venta.UltimaVenta().Rows[0]["final"].ToString();
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

        private void button6_MouseEnter(object sender, EventArgs e)
        {
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.Teal;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.Coral;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.BackColor = Color.Teal;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.BackColor = Color.Coral;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Teal;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Coral;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Todas td = new Todas();
            td.ShowDialog();
        }

        private void btnTodo_MouseEnter(object sender, EventArgs e)
        {
            btnTodo.BackColor = Color.Teal;
        }

        private void btnTodo_MouseLeave(object sender, EventArgs e)
        {
            btnTodo.BackColor = Color.Coral;
        }
    }
}
