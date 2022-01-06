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
    public partial class FormProducto : Form
    {
        public bool Editar_PRODUCTO = false;
        ClsProveedor Prov = new ClsProveedor();
        ClsCategoria cate = new ClsCategoria();
        ClsProducto pro = new ClsProducto();
        Validacion val = new Validacion();
        public FormProducto()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void Listado_Categoria() {
            comboBox1.DataSource = cate.ListarCategoria();
            comboBox1.DisplayMember = "nom_cate";
            comboBox1.ValueMember = "cod_cate";
        }
        public void Listado_Proveedor() {
            comboBox2.DataSource = Prov.ListarProveedor();
            comboBox2.DisplayMember = "nom_prov";
            comboBox2.ValueMember = "cod_prov";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void FormProducto_Load(object sender, EventArgs e)
        {
            Listado_Categoria();
            Listado_Proveedor();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (Editar_PRODUCTO == false)
                {
                    if (val.ValidarLetras(textBox1.Text) == true && val.ValidarNumero(textBox3.Text) == true)
                    {
                        pro.P_cod_cate = Convert.ToString(comboBox1.SelectedValue);
                        pro.P_cod_prov = Convert.ToString(comboBox2.SelectedValue);
                        pro.P_nom_pro = textBox1.Text;
                        pro.P_precio = textBox2.Text;
                        pro.P_stock = textBox3.Text;
                        pro.P_fecha_venc = dateTimePicker1.Text;

                        MessageBox.Show(pro.NuevoProducto(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else {
                        MessageBox.Show("SOLO PUEDES INGRESAR LETRAS SIN NINGUN CARACTER ESPECIAL Y SOLO NUMEROS EN LA CASILLA 'STOCK'", "!AVISO");
                    }
                }
                if (Editar_PRODUCTO == true)
                {
                    if (val.ValidarLetras(textBox1.Text) == true && val.ValidarNumero(textBox3.Text) == true)
                    {
                        pro.P_cod_cate = Convert.ToString(comboBox1.SelectedValue);
                        pro.P_cod_prov = Convert.ToString(comboBox2.SelectedValue);
                        pro.P_nom_pro = textBox1.Text;
                        pro.P_precio = textBox2.Text;
                        pro.P_stock = textBox3.Text;
                        pro.P_fecha_venc = dateTimePicker1.Text;

                        MessageBox.Show(pro.EditarProducto(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Editar_PRODUCTO = false;
                    }
                    else
                    {
                        MessageBox.Show("SOLO PUEDES INGRESAR LETRAS SIN NINGUN CARACTER ESPECIAL Y SOLO NUMEROS EN LA CASILLA 'STOCK'", "!AVISO");
                    }
                }
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
