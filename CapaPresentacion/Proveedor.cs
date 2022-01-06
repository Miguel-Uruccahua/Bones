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
    public partial class Proveedor : Form
    {
        ClsProveedor prov = new ClsProveedor();
        Validacion val = new Validacion();
        public Proveedor()
        {
            InitializeComponent();
            Listado_Proveedor();
            dataGridView1.Columns["nom_prov"].ReadOnly = true;
            dataGridView1.Columns["dir_prov"].ReadOnly = true;
            dataGridView1.Columns["telef_prov"].ReadOnly = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            try {
                if (val.ValidarLetras(textBox1.Text)==true&&val.ValidarDNI(textBox3.Text)==true)
                {
                    prov.PR_nom_prov = textBox1.Text;
                    prov.PR_dir_prov = textBox2.Text;
                    prov.PR_telefono = textBox3.Text;
                    MessageBox.Show(prov.NuevoProveedor(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else {
                    MessageBox.Show("DEBE COMPLETAR LOS DATOS SIN NINGUN CARACTER ESPECIAL Y/O SOLO 8 DIGITOS EN EL TELEFONO", "Aviso");
                }
            } catch (Exception ex) { throw ex; }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            Listado_Proveedor();
        }

        private void Proveedor_Load(object sender, EventArgs e)
        {

        }
        public void Listado_Proveedor() {
            dataGridView1.DataSource = prov.ListarProveedor();
            dataGridView1.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    prov.PR_nom_prov = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    MessageBox.Show(prov.EliminarProveedor(), "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Question);
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
            Listado_Proveedor();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.Teal;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.Coral;
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
