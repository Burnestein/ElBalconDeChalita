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
                string consulta = "SELECT * FROM clientes";
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

        public DataTable ConsultarClientes(string cadena)
        {
            string busqueda = cadena;
            MySqlConnection conexionBD = mysql.conexion.Conexion();
            conexionBD.Open();

            try
            {
                string consulta = "" +
                    "SELECT * FROM clientes " +
                    "WHERE " +
                    "nombre LIKE @Busqueda" +
                    " OR apellidoPaterno LIKE @Busqueda" +
                    " OR apellidoMaterno LIKE @Busqueda" +
                    " OR numCelular LIKE @Busqueda" +
                    " OR email LIKE @Busqueda" +
                    " OR codigoCliente LIKE @Busqueda";
                MySqlCommand comando = new MySqlCommand(consulta, conexionBD);
                comando.Parameters.AddWithValue("@Busqueda", "%" + busqueda + "%"); //"%" para indicar que debe incluir cualquier valor que contenga la cadena busqueda en cualquier posicion

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
