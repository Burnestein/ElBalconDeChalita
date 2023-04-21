using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace El_Balcon_de_Chalita
{
    public partial class busquedaclientes : Form
    {
        consulta miconsulta = new consulta();
        public busquedaclientes()
        {
            InitializeComponent();
            
            
            
        }

        public void buscarClientes(string busqueda)
        {
            dgvBuscCliente.DataSource = miconsulta.ConsultarClientes(busqueda);
        }

        private void btnBuscCanc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
