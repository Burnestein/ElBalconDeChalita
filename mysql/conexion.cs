﻿using System;
using MySql.Data.MySqlClient;

namespace El_Balcon_de_Chalita.mysql
{
    class conexion
    {
        public static MySqlConnection Conexion()
        {

            string servidor = "127.0.0.1";
            string basededatos = "bdbalcon";
            string usuario = "root";
            string password = "";

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
