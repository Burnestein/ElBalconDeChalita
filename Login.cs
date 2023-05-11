using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Runtime.InteropServices;

namespace El_Balcon_de_Chalita
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = null;////
            string user = usuario.Text;
            string pass = contraseña.Text;
            string contraseaEncriptada = Encrypt.GetSHA256(pass);
            string query = "select * from usuarios where email = '" + user + "' and password = '" + contraseaEncriptada + "' ";

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
                    MessageBox.Show("Login exitoso");
                    contabilidad contab = new contabilidad();
                    //contab.Show();
                    DlgBalconDeChalita mibalcon = new DlgBalconDeChalita();
                    mibalcon.Show();
                    this.Visible = false;

                    while (reader.Read())
                    {
                        //cbxClientes.Items.Add(reader.GetString(6) + "-" + reader.GetString(1));

                    }
                    //cbxClientes.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Revise sus credenciales de acceso");
                }

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

        public void prueba(string material)
        {
            MySqlDataReader reader = null;
           // Query para obtener toda la info de los clientes registrados en la BD
            string query = "SELECT* FROM clientes";
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
                        //cbxClientes.Items.Add(reader.GetString(6) + "-" + reader.GetString(1));

                    }
                    //cbxClientes.SelectedIndex = 0;
                }

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

        private void contraseña_TextChanged(object sender, EventArgs e)
        {
            contraseña.PasswordChar = '*';
        }

        private void PbxCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estas seguro que deseas cerrar?", "Cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        //Inicio para poder arrastarar el panel con el mouse
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }




        //Fin para poder arrastarar el panel con el mouse
    }
}
