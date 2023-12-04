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
using System.Globalization;

namespace El_Balcon_de_Chalita
{
    public partial class contabilidad : Form
    {
        private float totalIngresos = 0;
        private float totalEgresos = 0;
        private DlgBalconDeChalita mibalcon;

        public contabilidad(user miusuario)
        {
            InitializeComponent();
            ingresos();
            egresos();
            ganancias();
            mibalcon = new DlgBalconDeChalita(miusuario);

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
                        row.Cells[1].Value = reader.GetString(2);
                        row.Cells[2].Value = reader.GetString(5);
                        DgbIngresos.Rows.Add(row);
                        totalIngresos += int.Parse(reader.GetString(5)) ;
                        contador++;

                    }
                    
                    //cbxClientes.SelectedIndex = 0;
                }
                DgbIngresos.Sort(DgbIngresos.Columns[1], ListSortDirection.Descending);
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
                        row.Cells[1].Value = reader.GetString(2);
                        row.Cells[2].Value = reader.GetString(7);
                        row.Cells[3].Value = reader.GetString(8);
                        row.Cells[4].Value = (float.Parse(reader.GetString(5))/100) * float.Parse(reader.GetString(8));
                        row.Cells[5].Value = 150;
                        gastosLimpieza += 150;
                        gastosCompañiaAfiliada += (float.Parse(reader.GetString(5)) / 100) * float.Parse(reader.GetString(8));
                        DgbEgresos.Rows.Add(row);
                        //totalIngresos += int.Parse(reader.GetString(5));
                        contador++;

                    }
                    //cbxClientes.SelectedIndex = 0;
                }
                DgbEgresos.Sort(DgbEgresos.Columns[1], ListSortDirection.Descending);
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

        private void btnContaConsulta_Click(object sender, EventArgs e)
        {
            totalIngresos = 0;
            totalEgresos = 0;
            DgbIngresos.DataSource = null;
            DgbEgresos.DataSource = null;
            DgbIngresos.Rows.Clear();
            DgbEgresos.Rows.Clear();

            MySqlDataReader reader = null;

            DateTime dtpStartDate = dtpContaDe.Value;
            DateTime dtpEndDate = dtpContaHasta.Value;
            string startDate = dtpStartDate.ToString("yyyy/MM/dd");
            string endDate = dtpEndDate.ToString("yyyy/MM/dd");

            //MessageBox.Show(startDate);
            //MessageBox.Show(endDate);

            // Convertir las fechas a formato de fecha reconocido por MySQL
            DateTime parsedStartDate = DateTime.ParseExact(startDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            DateTime parsedEndDate = DateTime.ParseExact(endDate, "yyyy/MM/dd", CultureInfo.InvariantCulture);

            // Construir la consulta SQL con el filtro de fechas
            //string query = "SELECT * FROM nombre_tabla WHERE fecha_columna BETWEEN @startDate AND @endDate";

            string query = "select * from reservaciones left join compañiasafiliadas on  reservaciones.compañiaAfiliada = compañiasafiliadas.idCompañia WHERE STR_TO_DATE(fechaEntrada, '%Y/%m/%d') BETWEEN @startDate AND @endDate";

            //Instanciamos la clase de MysqlConnection 
            MySqlConnection conexionBD = mysql.conexion.Conexion();
            //Abrimos la conexion a la BD
            conexionBD.Open();
            //Ejecutamos bloque try - catch para ejecutar el query de consulta
            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionBD);
                comando.Parameters.AddWithValue("@startDate", parsedStartDate);
                comando.Parameters.AddWithValue("@endDate", parsedEndDate);
                reader = comando.ExecuteReader();
                int contador = 0;

                //Si la consulta trae resultados, se llenara el combobox de clientes
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataGridViewRow row = (DataGridViewRow)DgbIngresos.Rows[contador].Clone();
                        row.Cells[0].Value = reader.GetString(0);
                        row.Cells[1].Value = reader.GetString(2);
                        row.Cells[2].Value = reader.GetString(5);
                        DgbIngresos.Rows.Add(row);
                        totalIngresos += int.Parse(reader.GetString(5));
                        contador++;

                    }
                    //cbxClientes.SelectedIndex = 0;
                }
                DgbIngresos.Sort(DgbIngresos.Columns[1], ListSortDirection.Descending);
                txtIngresos.Text = "$" + totalIngresos.ToString();

                

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Ocurrio un error en la consulta:" + ex.Message);
            }
            finally
            {
                conexionBD.Close();
            }

            reader = null;
            query = "select * from reservaciones left join compañiasafiliadas on  reservaciones.compañiaAfiliada = compañiasafiliadas.idCompañia WHERE STR_TO_DATE(fechaEntrada, '%Y/%m/%d') BETWEEN @startDate AND @endDate";

            //Instanciamos la clase de MysqlConnection 
            //Abrimos la conexion a la BD
            conexionBD.Open();
            //Ejecutamos bloque try - catch para ejecutar el query de consulta
            try
            {
                MySqlCommand comando2 = new MySqlCommand(query, conexionBD);
                comando2.Parameters.AddWithValue("@startDate", parsedStartDate);
                comando2.Parameters.AddWithValue("@endDate", parsedEndDate);
                reader = comando2.ExecuteReader();
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
                        row.Cells[1].Value = reader.GetString(2);
                        row.Cells[2].Value = reader.GetString(7);
                        row.Cells[3].Value = reader.GetString(8);
                        row.Cells[4].Value = (float.Parse(reader.GetString(5)) / 100) * float.Parse(reader.GetString(8));
                        row.Cells[5].Value = 150;
                        gastosLimpieza += 150;
                        gastosCompañiaAfiliada += (float.Parse(reader.GetString(5)) / 100) * float.Parse(reader.GetString(8));
                        DgbEgresos.Rows.Add(row);
                        //totalIngresos += int.Parse(reader.GetString(5));
                        contador++;

                    }
                    //cbxClientes.SelectedIndex = 0;
                }
                DgbEgresos.Sort(DgbEgresos.Columns[1], ListSortDirection.Descending);
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
            ganancias();
        }

        private void btnContaReporte_Click(object sender, EventArgs e)
        {
            mibalcon.BindReportIE();
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

        private void txtGanancias_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

    }
}
