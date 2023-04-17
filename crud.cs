using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace El_Balcon_de_Chalita
{
    public class crud
    {
        protected string tablaConsulta = "";
        protected string queryEliminar = "";
        public List<string> leer()
        {
            //Instanciamos la clase de Mysql para la lectura de registros en BD
            MySqlDataReader reader = null;
            List<string> listaResultados = new List<string>();

            //Query para obtener toda la info de los clientes registrados en la BD
            string query = "SELECT* FROM "+tablaConsulta+" ";
            //Instanciamos la clase de MysqlConnection 
            MySqlConnection conexionBD = mysql.conexion.Conexion();
            //Abrimos la conexion a la BD
            conexionBD.Open();
            //Ejecutamos bloque try - catch para ejecutar el query de consulta
            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionBD);
                reader = comando.ExecuteReader();
                //Si la consulta trae resultados, se llenara el combobox de clientes
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        switch (tablaConsulta)
                        {
                            case "clientes":
                                listaResultados.Add(reader.GetString(6) + "-" + reader.GetString(1));
                                break;
                            case "compañiasafiliadas":
                                listaResultados.Add(reader.GetString(0) + "-" + reader.GetString(1));
                                break;
                        }


                    }
                }
                reader.Close();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ocurrio un error en la consulta:" + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
            return listaResultados;
        }

        public void eliminar()
        {
            String query = queryEliminar;
            MessageBox.Show(query);

            MySqlConnection conexionBD = mysql.conexion.Conexion();
            conexionBD.Open();
            try
            {
                MySqlCommand accion = new MySqlCommand(query, conexionBD);
                accion.ExecuteNonQuery();
                MessageBox.Show("Registro eliminado");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al eliminar el registro:" + ex.Message);
            }
        }
    }
}
