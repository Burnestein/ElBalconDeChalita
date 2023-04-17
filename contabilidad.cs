using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace El_Balcon_de_Chalita
{
    public partial class contabilidad : Form
    {
        private float totalIngresos = 0;
        private float totalEgresos = 0;
        public contabilidad()
        {
            InitializeComponent();
            ingresos();
            egresos();
            ganancias();
        }

        private void ingresos()
        {
            MySqlDataReader reader = null;
            string query = "select * from reservaciones left join compañiasafiliadas on  reservaciones.compañiaAfiliada = compañiasafiliadas.idCompañia ";

            //Instanciamos la clase de MysqlConnection 
            MySqlConnection conexionBD = mysql.conexion.Conexion();
            //Abrimos la conexion a la BD
            conexionBD.Open();
            //Ejecutamos bloque try - catch para ejecutar el query de consulta
            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionBD);
                reader = comando.ExecuteReader();
                int contador = 0;
                
                //Si la consulta trae resultados, se llenara el combobox de clientes
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataGridViewRow row = (DataGridViewRow)DgbIngresos.Rows[contador].Clone();
                        row.Cells[0].Value = reader.GetString(0);
                        row.Cells[1].Value = reader.GetString(5);
                        DgbIngresos.Rows.Add(row);
                        totalIngresos += int.Parse(reader.GetString(5)) ;
                        contador++;

                    }
                    //cbxClientes.SelectedIndex = 0;
                }
                txtIngresos.Text = "$"+totalIngresos.ToString();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ocurrio un error en la consulta:" + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }

        }
        private void egresos()
        {
            MySqlDataReader reader = null;
            string query = "select * from reservaciones left join compañiasafiliadas on  reservaciones.compañiaAfiliada = compañiasafiliadas.idCompañia ";

            //Instanciamos la clase de MysqlConnection 
            MySqlConnection conexionBD = mysql.conexion.Conexion();
            //Abrimos la conexion a la BD
            conexionBD.Open();
            //Ejecutamos bloque try - catch para ejecutar el query de consulta
            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionBD);
                reader = comando.ExecuteReader();
                int contador = 0;
                float gastosLimpieza = 0;
                float gastosCompañiaAfiliada = 0;

                //Si la consulta trae resultados, se llenara el combobox de clientes
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataGridViewRow row = (DataGridViewRow)DgbEgresos.Rows[contador].Clone();
                        row.Cells[0].Value = reader.GetString(0);
                        row.Cells[1].Value = reader.GetString(7);
                        row.Cells[2].Value = reader.GetString(8);
                        row.Cells[3].Value = (float.Parse(reader.GetString(5))/100) * float.Parse(reader.GetString(8));
                        row.Cells[4].Value = 150;
                        gastosLimpieza += 150;
                        gastosCompañiaAfiliada += (float.Parse(reader.GetString(5)) / 100) * float.Parse(reader.GetString(8));
                        DgbEgresos.Rows.Add(row);
                        //totalIngresos += int.Parse(reader.GetString(5));
                        contador++;

                    }
                    //cbxClientes.SelectedIndex = 0;
                }
                totalEgresos = gastosLimpieza + gastosCompañiaAfiliada;
                txtEgresos.Text = "$" + totalEgresos.ToString();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ocurrio un error en la consulta:" + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void ganancias()
        {
            float ganaciasTotales = totalIngresos - totalEgresos;
            txtGanancias.Text = "$"+ganaciasTotales.ToString();
        }

        private void contabilidad_Load(object sender, EventArgs e)
        {

        }

        private void Ingresos_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void DgbIngresos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


    }
}
