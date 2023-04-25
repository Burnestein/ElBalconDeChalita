﻿using System;
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
        public DlgBalconDeChalita formpadre { get; set; }
        consulta miconsulta = new consulta();
        cliente micliente = new cliente();
        
        
        public busquedaclientes(cliente micliente)
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

        private void btnBuscAcept_Click(object sender, EventArgs e)
        {
            
            formpadre.MiCliente = SeleccionarCliente();
            formpadre.ActualizarForm();
            //mibalcon.ActualizarForm();
            
            this.Close();

        }

        public cliente SeleccionarCliente()
        {
            
            int selectedIndex = dgvBuscCliente.CurrentCell.RowIndex;
            micliente.IdCliente = dgvBuscCliente[0, selectedIndex].Value.ToString();
            micliente.Nombre = dgvBuscCliente[1, selectedIndex].Value.ToString();
            micliente.ApellidoPaterno = dgvBuscCliente[2, selectedIndex].Value.ToString();
            micliente.ApellidoMaterno = dgvBuscCliente[3, selectedIndex].Value.ToString();
            micliente.NumCelular = dgvBuscCliente[4, selectedIndex].Value.ToString();
            micliente.Email = dgvBuscCliente[5, selectedIndex].Value.ToString();
            micliente.CodigoCliente = dgvBuscCliente[6, selectedIndex].Value.ToString();
            micliente.Genero = dgvBuscCliente[7, selectedIndex].Value.ToString();
            micliente.LugarProcedencia = dgvBuscCliente[8, selectedIndex].Value.ToString();
            micliente.EstadoCivil = dgvBuscCliente[9, selectedIndex].Value.ToString();
            micliente.FechaNacimiento = dgvBuscCliente[10, selectedIndex].Value.ToString();
            return micliente;
        }
    }
}
