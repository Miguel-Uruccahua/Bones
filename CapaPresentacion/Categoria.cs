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
    public partial class Categoria : Form
    {
        ClsCategoria cate = new ClsCategoria();
        public Categoria()
        {
            InitializeComponent();
            Listado_Categoria();
            dataGridView1.Columns["nom_cate"].ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Validacion val = new Validacion();
                if (val.ValidarLetras(textBox1.Text) == true)
                {
                    cate.C_nom_cate = textBox1.Text;
                    MessageBox.Show(cate.NuevaCategoria(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("SOLO DEBE INGRESAR LETRAS SIN NINGUN CARACTER ESPECIAL", "AVISO");
                }
            }catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
            Listado_Categoria();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    cate.C_nom_cate = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    MessageBox.Show(cate.EliminarCategoria(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
            Listado_Categoria();
        }

        private void Categoria_Load(object sender, EventArgs e)
        {
            
        }
        public void Listado_Categoria()
        {
            dataGridView1.DataSource = cate.ListarCategoria();
            dataGridView1.Columns[0].Visible = false;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.Teal;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.Coral;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.Teal;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.Coral;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Teal;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Coral;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
