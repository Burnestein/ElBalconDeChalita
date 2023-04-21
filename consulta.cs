using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Data;

namespace El_Balcon_de_Chalita
{
    public class consulta
    {
        

        public DataTable ConsultarClientes()
        {
            MySqlConnection conexionBD = mysql.conexion.Conexion();
            conexionBD.Open();

            try
            {
                string consulta = "SELECT * FROM Clientes";
                MySqlCommand comando = new MySqlCommand(consulta, conexionBD);

                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable tablaClientes = new DataTable();
                adaptador.Fill(tablaClientes);

                return tablaClientes;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al realizar la consulta:" + ex.Message);
                return null;
            }
            
        }
    }


}
