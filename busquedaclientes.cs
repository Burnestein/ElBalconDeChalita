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
        
        public busquedaclientes()
        {
            InitializeComponent();
            consulta miconsulta = new consulta();
            dgvBuscCliente.DataSource = miconsulta.ConsultarClientes();
        }

        private void btnBuscCanc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
