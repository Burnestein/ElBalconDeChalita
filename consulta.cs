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
        
        public DataGridView ConsultarReservaciones(DataGridView tabla)
        {
            DataGridView DgbReservaciones = tabla;
            //Query para obtener las reservas enlazadas con los id de los clientes en su respectiva tabla
            string obtenerReservas = "select * from reservaciones left join clientes on reservaciones.cliente = clientes.idCliente";
            MySqlDataReader reader = null;
            MySqlConnection conexionBD = mysql.conexion.Conexion();
            conexionBD.Open();
            //Contador que sera el puntero para el numero de fila en la que se ira insertando la data de la BD
            int contador = 0;
            //Limpiamos el datagrid
            DgbReservaciones.Rows.Clear();
            DgbReservaciones.Refresh();
            try
            {
                MySqlCommand comand = new MySqlCommand(obtenerReservas, conexionBD);
                reader = comand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string nombreCliente = reader.GetString(7) + " " + reader.GetString(8) + " " + reader.GetString(9);
                        DataGridViewRow row = (DataGridViewRow)DgbReservaciones.Rows[contador].Clone();
                        row.Cells[0].Value = reader.GetString(0);
                        row.Cells[1].Value = nombreCliente;
                        row.Cells[2].Value = reader.GetString(2);
                        row.Cells[3].Value = reader.GetString(3);
                        DgbReservaciones.Rows.Add(row);
                        contador++;
                    }
                }
                return DgbReservaciones;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        public DataGridView ConsultarReservaciones(DataGridView tabla, cliente cliente)
        {
            MySqlConnection conexionBD = mysql.conexion.Conexion();
            conexionBD.Open();
            DataGridView DgbReservaciones = tabla;
            int idCliente = cliente.IdCliente;
            MessageBox.Show("El Id del cliente actual es: " + idCliente.ToString());
            //Query para obtener las reservas enlazadas con los id de los clientes en su respectiva tabla
            string obtenerReservas = "select * from reservaciones left join clientes on reservaciones.cliente = clientes.idCliente WHERE clientes.idCliente LIKE @idCliente";
            
            MySqlDataReader reader = null;
            //Contador que sera el puntero para el numero de fila en la que se ira insertando la data de la BD
            int contador = 0;
            //Limpiamos el datagrid
            DgbReservaciones.Rows.Clear();
            DgbReservaciones.Refresh();
            try
            {
                MySqlCommand comando = new MySqlCommand(obtenerReservas, conexionBD);
                comando.Parameters.AddWithValue("@idCliente", idCliente);
                reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string nombreCliente = reader.GetString(7) + " " + reader.GetString(8) + " " + reader.GetString(9);
                        DataGridViewRow row = (DataGridViewRow)DgbReservaciones.Rows[contador].Clone();
                        row.Cells[0].Value = reader.GetString(0);
                        row.Cells[1].Value = nombreCliente;
                        row.Cells[2].Value = reader.GetString(2);
                        row.Cells[3].Value = reader.GetString(3);
                        DgbReservaciones.Rows.Add(row);
                        contador++;
                    }
                }
                return DgbReservaciones;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }
    }


}
