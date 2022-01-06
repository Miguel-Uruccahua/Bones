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
    public partial class Todas : Form
    {
        Venta cl = new Venta();
        public Todas()
        {
            
            InitializeComponent();
            Listado_Ventas();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void Listado_Ventas()
        {
            dataGridView1.DataSource = cl.ListadoPedido();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Enabled = false;
        }

        private void Todas_Load(object sender, EventArgs e)
        {

        }
    }
}
