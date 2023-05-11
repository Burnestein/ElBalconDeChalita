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
            finally
            {
                conexionBD.Close();
            }

        }
        public int TipoUsuario(string usuario)
        {
            MySqlConnection conexionBD = mysql.conexion.Conexion();

            // Define la consulta SQL para buscar el usuario y contraseña
            string sqlQuery = "SELECT id_rol FROM usuarios WHERE email=@usuario";

            // Crea un objeto MySqlCommand para ejecutar la consulta SQL
            MySqlCommand command = new MySqlCommand(sqlQuery, conexionBD);

            // Añade los parámetros de la consulta SQL
            command.Parameters.AddWithValue("@usuario", usuario);

            // Abre la conexión a la base de datos
            conexionBD.Open();

            // Ejecuta la consulta SQL y obtiene el resultado
            object result = command.ExecuteScalar();

            // Cierra la conexión a la base de datos
            conexionBD.Close();

            // Verifica si el resultado es nulo
            if (result != null)
            {
                // Convierte el resultado a entero y guárdalo en una variable
                int idRol = Convert.ToInt32(result);
                //MessageBox.Show(idRol.ToString());
                return idRol;
                // Hace lo que necesites con el idRol obtenido
            }
            else
            {
                // Si el resultado es nulo, significa que el usuario y/o contraseña no son correctos
                // Agrega aquí el código para mostrar un mensaje de error al usuario
                return -1;
            }
        }
        public DataTable ConsultarClientes(string texto)
        {
            string busqueda = texto;
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
            finally
            {
                conexionBD.Close();
            }

        }


        public DataGridView ConsultarReservaciones(DataGridView tabla)
        {
            DataGridView DgbReservaciones = tabla;
            //Query para obtener las reservas enlazadas con los id de los clientes en su respectiva tabla
            string obtenerReservas = "SELECT * FROM reservaciones " +
                                     "LEFT JOIN clientes ON reservaciones.cliente = clientes.idCliente " +
                                     "LEFT JOIN compañiasafiliadas ON reservaciones.compañiaAfiliada = compañiasafiliadas.idCompañia";
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
                        row.Cells[4].Value = reader.GetString(18);
                        row.Cells[5].Value = reader.GetString(4);
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
            finally
            {
                conexionBD.Close();
            }

        }

        public DataGridView ConsultarReservaciones(DataGridView tabla, cliente cliente)
        {
            MySqlConnection conexionBD = mysql.conexion.Conexion();
            conexionBD.Open();
            DataGridView DgbReservaciones = tabla;
            int idCliente = cliente.IdCliente;
            //Query para obtener las reservas enlazadas con los id de los clientes en su respectiva tabla
            string obtenerReservas = "SELECT * FROM reservaciones " +
                                     "LEFT JOIN clientes ON reservaciones.cliente = clientes.idCliente " +
                                     "LEFT JOIN compañiasafiliadas ON reservaciones.compañiaAfiliada = compañiasafiliadas.idCompañia " +
                                     "WHERE clientes.idCliente LIKE @idCliente";

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
                        row.Cells[4].Value = reader.GetString(18);
                        row.Cells[5].Value = reader.GetString(4);
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
            finally
            {
                conexionBD.Close();
            }

        }

        public void consultarInventario(DataGridView tabla, string insumo, string cantidad)
        {
            int contador = 0;
            MySqlDataReader reader = null;
            string query = "select * from inventariobalcon where nombre = '" + insumo + "' ";
            MySqlConnection conexionBD = mysql.conexion.Conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionBD);
                reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataGridViewRow row = (DataGridViewRow)tabla.Rows[contador].Clone();
                        row.Cells[0].Value = reader.GetString(1);
                        row.Cells[1].Value = reader.GetString(2);
                        row.Cells[2].Value = reader.GetString(3);
                        tabla.Rows.Add(row);
                        contador++;
                    }
                }
                else
                {
                    //MessageBox.Show("No hay objetos con ese nomnre.");
                    consultarInventario(tabla);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }

        }
        public void consultarInventario(DataGridView tabla)
        {
            int contador = 0;
            MySqlDataReader reader = null;
            string query = "select * from inventariobalcon";
            MySqlConnection conexionBD = mysql.conexion.Conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionBD);
                reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataGridViewRow row = (DataGridViewRow)tabla.Rows[contador].Clone();
                        row.Cells[0].Value = reader.GetString(1);
                        row.Cells[1].Value = reader.GetString(2);
                        row.Cells[2].Value = reader.GetString(3);
                        tabla.Rows.Add(row);
                        contador++;
                    }
                }
                else
                {
                    MessageBox.Show("No hay objetos con ese nomnre.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        public void consultarInventarioClientes(DataGridView tabla, cliente micliente)
        {
            MySqlDataReader reader = null;
            //Obtenemos el valor del input seleccionado
            //string nombreCliente = CbxClientesInventarioClientes.GetItemText(CbxClientesInventarioClientes.SelectedItem);
            //Hacemos un split para obtener solamente la clave del cliente
            //string[] obtenerClaveCliente = nombreCliente.Split('-');
            //string idCliente = obtenerClaveCliente[0];
            int idCliente = micliente.IdCliente;
            string query = "select * from inventarioclientes where idCliente = '" + idCliente + "' ";
            int contador = 0;
            if (idCliente > -1)
            {
                //Limpiamos el datagrid
                tabla.Rows.Clear();
                tabla.Refresh();

                MySqlConnection conexionBD = mysql.conexion.Conexion();
                conexionBD.Open();

                try
                {
                    MySqlCommand comando = new MySqlCommand(query, conexionBD);
                    reader = comando.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            DataGridViewRow row = (DataGridViewRow)tabla.Rows[contador].Clone();
                            row.Cells[0].Value = reader.GetString(1);
                            row.Cells[1].Value = reader.GetString(2);
                            row.Cells[2].Value = reader.GetString(4);
                            tabla.Rows.Add(row);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El cliente no tiene inventario registrado");
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente para la busqueda de su inventario");
            }
        }

    }
}
