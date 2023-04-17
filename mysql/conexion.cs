using System;
using MySql.Data.MySqlClient;

namespace El_Balcon_de_Chalita.mysql
{
    class conexion
    {
        public static MySqlConnection Conexion()
        {

            string servidor = "212.1.208.51";
            string basededatos = "u778442198_elbalcon";
            string usuario = "u778442198_root";
            string password = "Oscar2490";

            string cadenaConexion = "Database=" + basededatos + "; Data Source=" + servidor + "; User Id= " + usuario + "; Password=" + password + "";


            try
            {
                MySqlConnection conexionBD = new MySqlConnection(cadenaConexion);

                return conexionBD;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }

    }
}
