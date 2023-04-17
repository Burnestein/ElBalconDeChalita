
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;

using System.Text.RegularExpressions;

namespace El_Balcon_de_Chalita
{
    //----------------------------------------------------------------------------
    //Dialogo Principal del Proyecto Final.
    //CHVKM.16/10/21
    //-------------------------------------------------------------------------
    public partial class DlgBalconDeChalita : Form
    {
        //---------------------------------------------------------------------
        //Variables publicas dentro de la clase
        //---------------------------------------------------------------------
        private string fechaEntrada = "";
        private string fechaSalida = "";
        private string idCliente = "";
        private string correoCliente = "";
        private double totalReserva = 0;
        private string idCompañia = "";
        //---------------------------------------------------------------------
        //Atributo.
        //---------------------------------------------------------------------


        //---------------------------------------------------------------------
        //Constructor-Es lo primero que se ejecuta al abrir el programa con esta clase
        //---------------------------------------------------------------------
        public DlgBalconDeChalita()

        {
            //Se inicializa el componente
            InitializeComponent();
            //Generamos el codigo en automatico del cliente
            generarCodigoCliente();
            //Llenamos los combobox de los clientes y compañias afiliadas
            llenarComboBoxClientes();
            llenarComboBoxCompañiasAfiliadas();
            
        }

        private void llenarComboBoxClientes()
        {
            cliente cliente = new cliente();
            cliente.asignarTablaConsulta("clientes");
            List<string> clientes = cliente.leer();


            for (int i = 0; i < clientes.Count; i++)
            {
                CbxClientes.Items.Add(clientes[i]);
                CbxClientesInventarioClientes.Items.Add(clientes[i]);
            }
            
        }

        private void llenarComboBoxCompañiasAfiliadas()
        {
            cliente compañias = new cliente();
            compañias.asignarTablaConsulta("compañiasafiliadas");
            List<string> listaCompañias = compañias.leer();


            for (int i = 0; i < listaCompañias.Count; i++)
            {
                cbxCompañias.Items.Add(listaCompañias[i]);
            }

        }
        private void generarCodigoCliente()
        {
            //Creamos el objeto para crear el codigo a partir de la clase generadorRandom()
            generadorRandom random = new generadorRandom();
            int claveRandom = random.generarNumeroRandom();

            string contraseaEncriptada = Encrypt.GetSHA256("karmen");
            //MessageBox.Show(contraseaEncriptada);

            //Seteamos el codigo random en el input del codigo del cliente
            TbxCodigo.Text = claveRandom.ToString();
        }

        //---------------------------------------------------------------------
        //Cierra de la aplicacion.
        //---------------------------------------------------------------------
        private void TsbNuevo_Click(object sender, System.EventArgs e)
        {


            {

                TbxCodigo.Text = "";
                TbxNombre.Text = "";
                TbxApellidoP.Text = "";
                TbxApellidoM.Text = "";
                TbxTelefonoMovil.Text = "";
                TbxCorreo.Text = "";
                TbxLugarProcedencia.Text = "";
                CbxAño.SelectedIndex = -1;
                CbxMes.SelectedIndex = -1;
                CbxDia.SelectedIndex = -1;
                CbxEstadocivil.SelectedIndex = -1;
                CbxGenero.SelectedIndex = -1;

            }
            //---------------------------------------------------------------------
            //Elimina Un registro.
            //----------------------------------------------------------------------

        }
        /*
        Funcion para eliminar un cliente de la BD en base a su clave de registro
        @return void
        */
        private void TsbEliminar_Click(object sender, System.EventArgs e)
        {

            string codigo = TbxCodigo.Text;
            cliente cliente = new cliente();
            cliente.asignarQueryEliminar("DELETE FROM clientes where codigoCliente= '" + codigo + "' ");

            cliente.eliminar();
            limpiarCampos();
        }

        //---------------------------------------------------------------------
        //Funcion que inserta cliente en la BD
        //--
        private void TsbGuardar_Click(object sender, System.EventArgs e)
        {
            //------------------------------------------------------------------------------
            //Primero realiza la accion del try catch, luego se realiza la accion del if.
            //------------------------------------------------------------------------------
            try
            {
                //Toma el valor de todos los inputs
                string codigo = TbxCodigo.Text;
                string nombre = TbxNombre.Text;
                string apellidoP = TbxApellidoP.Text;
                string apellidoM = TbxApellidoM.Text;
                double telefono = double.Parse(TbxTelefonoMovil.Text);
                string correo = TbxCorreo.Text;
                string lugarprocedencia = TbxLugarProcedencia.Text;
                string año = CbxAño.GetItemText(CbxAño.SelectedItem);
                string mes = CbxMes.GetItemText(CbxMes.SelectedItem);
                string dia = CbxDia.GetItemText(CbxDia.SelectedItem);
                string estadoCivil = CbxEstadocivil.GetItemText(CbxEstadocivil.SelectedItem);
                string genero = CbxGenero.GetItemText(CbxGenero.SelectedItem);
                //Concatenamos la fecha en una variable
                string fechaNacimiento = dia + "-" + mes + "-" + año;
                //Si todos los campos estan llenos se procede a la insercion en BD
                if (codigo != "" && nombre != "" && apellidoP != "" && apellidoM != "" && telefono > 0 && correo != "" && lugarprocedencia != "" && año != "" && mes != ""

                    && dia != "" && estadoCivil != "" && genero != "")
                {
                   Regex mRegxExpression;    
                   mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                    if (mRegxExpression.IsMatch(correo.Trim()))
                    {
                        //Query para la insercion
                        string sql = "INSERT INTO  clientes(nombre,	apellidoPaterno,apellidoMaterno	,numCelular," +
                        "email,	codigoCliente,	genero,	lugarProcedencia,	estadoCivil,fechaNacimiento) VALUES ('" + nombre + "', '" + apellidoP + "','" + apellidoM + "','" + telefono + "','" + correo + "','" + codigo + "','" + genero + "','" + lugarprocedencia + "','" + estadoCivil + "','" + fechaNacimiento + "')";
                        //Instanciamos la clase de mysqlconnection
                        MySqlConnection conexionBD = mysql.conexion.Conexion();
                        //Abrimos la conexion a la BD
                        conexionBD.Open();
                        try
                        {
                            MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                            //Ejecutamos el query
                            comando.ExecuteNonQuery();
                            //Mostramos alerta de correcta ejecucion
                            MessageBox.Show("Registro guardado exitosamente");
                            CbxClientes.Items.Add(codigo+"-"+nombre);
                            CbxClientesInventarioClientes.Items.Add(codigo + "-" + nombre);
                            //Ejecutamos funcion para limpiar los campos
                            limpiarCampos();

                        }
                        //Cacha alguna excepcion en la insecion de la bd
                        catch (MySqlException ex)

                        {
                            MessageBox.Show("Error durante la insercion del registro: " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La dirección de correo no tiene un formato válido.");
                        TbxCorreo.Focus();
                    }
                }
                else { MessageBox.Show("Debes completar todos los campos."); }
            }//Cacha algun error en el formato de los datos
            catch (FormatException fex)
            {
                MessageBox.Show("Formato de los datos incorrecto:" + fex.Message);
            }

            //MessageBox.Show(sentenciaInsertar);
        }
        //---------------------------------------------------------------------
        //Funcion para limpiar todos los campos del formulario
        //----------------------------------------------------------------------
        private void limpiarCampos()
        {
            TbxCodigo.Text = "";
            TbxNombre.Text = "";
            TbxApellidoP.Text = "";
            TbxApellidoM.Text = "";
            TbxTelefonoMovil.Text = "";
            TbxCorreo.Text = "";
            TbxLugarProcedencia.Text = "";
            CbxAño.SelectedIndex = -1;
            CbxMes.SelectedIndex = -1;
            CbxDia.SelectedIndex = -1;
            CbxEstadocivil.SelectedIndex = -1;
            CbxGenero.SelectedIndex = -1;

        }
        //---------------------------------------------------------------------
        //Cierra de la aplicacion.
        //----------------------------------------------------------------------
        private void TsbCerrar_Click(object sender, System.EventArgs e)
        {
            {
                Close();
            }

        }
        /* Funcion para acutualizar algun cliente de la BD en base a su clave
        @return void */
        private void TsbActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                //Obtenemos los valor de los inputs del formulario
                string codigo = TbxCodigo.Text;
                string nombre = TbxNombre.Text;
                string apellidoP = TbxApellidoP.Text;
                string apellidoM = TbxApellidoM.Text;
                string telefono = TbxTelefonoMovil.Text;
                string correo = TbxCorreo.Text;
                string lugarprocedencia = TbxLugarProcedencia.Text;
                string año = CbxAño.GetItemText(CbxAño.SelectedItem);
                string mes = CbxMes.GetItemText(CbxMes.SelectedItem);
                string dia = CbxDia.GetItemText(CbxDia.SelectedItem);
                string estadoCivil = CbxEstadocivil.GetItemText(CbxEstadocivil.SelectedItem);
                string genero = CbxGenero.GetItemText(CbxGenero.SelectedItem);
                string fechaNacimiento = dia + "-" + mes + "-" + año;
                //Query para actualizacion de un cliente en BD
                string sql = "UPDATE clientes SET nombre ='" + nombre + "',	apellidoPaterno ='" + apellidoP + "',apellidoMaterno ='" + apellidoM + "'	,numCelular ='" + telefono + "',email ='" + correo + "',	genero ='" + genero + "',	lugarProcedencia ='" + lugarprocedencia + "',	estadoCivil ='" + estadoCivil + "',fechaNacimiento ='" + fechaNacimiento + "'" + "WHERE codigoCliente= '" + codigo + "'";
                //MessageBox.Show(sql);
                //  Abrimos la conexion a la base de datos
                MySqlConnection conexionBD = mysql.conexion.Conexion();
                conexionBD.Open();

                try
                {
                    //Instanciamos la clase que ejecutara el query
                    MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                    //Ejecutamos el metodo que hara el update en BD
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Registro modificado satisfactoriamente");
                    limpiarCampos();

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error al modificar el registro: " + ex.Message);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Datos incorrectos" + ex.Message);
            }

        }

        /* Funcion que consulta la info de un cliente y llena el formulario con esa informacion
        @return void  */
        private void TsbConsultar_Click(object sender, EventArgs e)
        {

            string codigo = TbxCodigo.Text;
            MySqlDataReader reader = null;

            string query = "SELECT* FROM clientes WHERE codigoCliente= '" + codigo + "' LIMIT 1";
            //Abrimos la conexion a la base de datos
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

                        TbxCodigo.Text = reader.GetString(6);
                        TbxNombre.Text = reader.GetString(1);
                        TbxApellidoP.Text = reader.GetString(2);
                        TbxApellidoM.Text = reader.GetString(3);
                        TbxTelefonoMovil.Text = reader.GetString(4);
                        TbxCorreo.Text = reader.GetString(5);
                        TbxLugarProcedencia.Text = reader.GetString(8);
                        //CbxEstadocivil.SelectedItem = reader.GetString(9);
                        string fecha = reader.GetString(10);
                        string[] fechaArray = fecha.Split('-');
                        CbxEstadocivil.SelectedIndex = CbxEstadocivil.FindString(reader.GetString(9));
                        CbxDia.SelectedIndex = CbxDia.FindString(fechaArray[0]);
                        CbxMes.SelectedIndex = CbxMes.FindString(fechaArray[1]);
                        CbxAño.SelectedIndex = CbxAño.FindString(fechaArray[2]);
                        CbxGenero.SelectedIndex = CbxGenero.FindString(reader.GetString(7));

                    }
                }
                else
                {
                    MessageBox.Show("No existe cliente con el codigo: " + TbxCodigo.Text);
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Error al realizar la consulta:" + ex.Message);
            }




        }

        private void calendario1_DateChanged(object sender, DateRangeEventArgs e)
        {
            fechaEntrada = CCheckIn.SelectionStart.Date.ToString("yyyy/MM/dd");
            if (fechaEntrada == fechaSalida)
            {
                MessageBox.Show("Debe elegir una fecha distinta.");

            }

            //MessageBox.Show(fechaEntrada);

        }

        private void calendario2_DateChanged(object sender, DateRangeEventArgs e)
        {
            fechaSalida = CCheckOut.SelectionStart.Date.ToString("yyyy/MM/dd");
            if (fechaEntrada == fechaSalida)
            {
                MessageBox.Show("Debe elegir una fecha distinta a la fecha de entrada.");

            }
            if (CCheckOut.SelectionRange.Start < CCheckIn.SelectionRange.Start)
            {
                MessageBox.Show("Debe seleccionar una fecha de salida mayor.");
            }
            DateTime dt1 = CCheckIn.SelectionRange.Start;

            DateTime dt2 = CCheckOut.SelectionRange.Start;
            TimeSpan difer = dt2 - dt1;
            double costo = 1500 * difer.TotalDays;
            txtTotal.Text = "$" + costo.ToString();
            totalReserva = costo;

            //double iva = (totalReserva / 100) * 16;
            //double subtotal = totalReserva + iva;
            double subtotal = totalReserva;
            txtSubTotal.Text = subtotal.ToString();
            //MessageBox.Show(fechaSalida);
        }


        //Funcion para obtener la info del cliente que seleccionemos en el combobox
        private void cbxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Obtenemos el valor del input seleccionado
            string nombreCliente = CbxClientes.GetItemText(CbxClientes.SelectedItem);
            //Hacemos un split para obtener solamente la clave del cliente
            string[] obtenerClaveCliente = nombreCliente.Split('-');
            //Intanciamos la clase de lectura de la libreria de myslq
            MySqlDataReader reader = null;
            //Armamos el query para seleccionar la data del cliente con la clave seleccionada
            string sqlObtenerData = "SELECT idCliente,email from clientes where codigoCliente = '" + obtenerClaveCliente[0] + "' LIMIT 1";
            //Entablamos la conexion con la BD
            MySqlConnection conexionBD = mysql.conexion.Conexion();
            conexionBD.Open();
            try
            {
                //Ejecutamos el query que nos leera la informacion de la BD
                MySqlCommand comand = new MySqlCommand(sqlObtenerData, conexionBD);
                reader = comand.ExecuteReader();
                //Si la consulta trae resultados se almacenara el id del Cliente y su correo en las variables publicas
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idCliente = reader.GetString(0);
                        correoCliente = reader.GetString(1);
                    }

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Boolean verificarFechaDisponible()
        {
            MySqlDataReader reader = null;
            string query = "select* from reservaciones where '" + fechaEntrada + "' <= fechaSalida and '" + fechaSalida + "' >= fechaEntrada";

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
                        return false;

                    }
                }
                else
                {
                    return true;
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
            return true;
        }
        //Boton que realizara toda la accion para las reservas
        //@return void
        private void btnReservar_Click(object sender, EventArgs e)
        {
            //En caso de que todos los campos rqueridos sean llenados se procede a guardar la reserva
            if (CbxClientes.SelectedIndex != -1 && fechaEntrada != "" && fechaSalida != "" && cbxCompañias.SelectedIndex != -1)
            {
                Boolean reservaDisponible = verificarFechaDisponible();
                if (reservaDisponible)
                {
                    //Se arma query de insercion a la BD en la tabla de reservaciones
                    string sql = "INSERT INTO reservaciones(cliente,fechaEntrada,fechaSalida,compañiaAfiliada,costoReservacion" +
                        ") VALUES('" + idCliente + "','" + fechaEntrada + "','" + fechaSalida + "','" + idCompañia + "','" + txtSubTotal.Text + "')  ";
                    //Se entabla la conexion a la BD
                    MySqlConnection conexionBD = mysql.conexion.Conexion();
                    conexionBD.Open();

                    try
                    {
                        //Se instancia la clase que ejecutara el query
                        MySqlCommand comando = new MySqlCommand(sql, conexionBD);
                        //Se ejecuta el query
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Reservacion guardada exitosamente");
                        //Una vez hecha la reserva mandamos correo al servidor SMTP de MailTrap
                        correo mandarCorreo = new correo();
                        mandarCorreo.nombreCorreo = correoCliente;
                        //Llamamos al metodo mandarCorreo
                        mandarCorreo.mandarCorreo();

                    }

                    catch (MySqlException ex)

                    {
                        MessageBox.Show("Error durante la insercion del registro: " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Estas fechas ya no se encuentran dsiponibles para su reserva");
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar todos los datos para su reserva.");

            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //Funcion que mostrara los datos de las reservas en un dataGrid al ejecutar evento de click en el boton de consulta reservas
        private void button1_Click(object sender, EventArgs e)
        {
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
                        string nombreCliente = reader.GetString(7)+" "+ reader.GetString(8)+" "+ reader.GetString(9);
                        DataGridViewRow row = (DataGridViewRow)DgbReservaciones.Rows[contador].Clone();
                        row.Cells[0].Value = reader.GetString(0);
                        row.Cells[1].Value = nombreCliente;
                        row.Cells[2].Value = reader.GetString(2);
                        row.Cells[3].Value = reader.GetString(3);
                        DgbReservaciones.Rows.Add(row);
                        contador++;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Un objeto es la instancia de una clase
            Login login = new Login();
            login.Show();

        }

      
        private void cbxCompañias_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Obtenemos el valor del input seleccionado
            string compañia = cbxCompañias.GetItemText(cbxCompañias.SelectedItem);
            //Hacemos un split para obtener solamente la clave de la compañia
            string[] obtenerClaveCompañia = compañia.Split('-');
            idCompañia = obtenerClaveCompañia[0];
        }

        private void btnGuardarObjeto_Click(object sender, EventArgs e)
        {
            string nombreObjeto = txtNombreObjeto.Text;
            string cantidad = txtCantidadObjeto.Text;
            string precio = txtPrecioObjeto.Text;
            if (nombreObjeto != "" && cantidad != "" && precio != "")
            {
                string query = "insert into inventariobalcon(nombre,cantidad,precio) values('" + nombreObjeto + "','" + cantidad + "','" + precio + "')";
                //Instanciamos la clase de MysqlConnection 
                MySqlConnection conexionBD = mysql.conexion.Conexion();
                //Abrimos la conexion a la BD
                conexionBD.Open();
                try
                {
                    MySqlCommand comando = new MySqlCommand(query, conexionBD);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Objeto guardado correctamente");
                    limpiarCamposFormInventario();
                   
                    DgbInventarioBalcon.Rows.Add(nombreObjeto,cantidad,precio);

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Ocurrio un error insertando el elemento:" + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
        }

        private void btnConsultarObjeto_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = null;
            string nombreObjeto = txtNombreObjeto.Text;
            string query = "select * from inventariobalcon where nombre = '"+nombreObjeto+"' ";
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
                        txtCantidadObjeto.Text = reader.GetString(2);
                        txtPrecioObjeto.Text = reader.GetString(3);
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
        }

        private void btnEditarObjeto_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreObjeto.Text;
            string precio = txtPrecioObjeto.Text;
            string cantidad = txtCantidadObjeto.Text;

            string query = "update inventariobalcon set nombre= '" + nombre + "',cantidad = '" + cantidad + "', precio = '" + precio + "' where nombre = '" + nombre + "' ";

            MySqlConnection conexionBD = mysql.conexion.Conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Objeto actualizado correctamente");
                limpiarCamposFormInventario();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnEliminarObjeto_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreObjeto.Text;
            string precio = txtPrecioObjeto.Text;
            string cantidad = txtCantidadObjeto.Text;

            string query = "delete from inventariobalcon where nombre= '" + nombre + "'";

            MySqlConnection conexionBD = mysql.conexion.Conexion();
            conexionBD.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionBD);
                comando.ExecuteNonQuery();
                MessageBox.Show("Objeto eliminado.");
                limpiarCamposFormInventario();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void limpiarCamposFormInventario()
        {
            txtCantidadObjeto.Text = "";
            txtNombreObjeto.Text = "";
            txtPrecioObjeto.Text = "";
        }

        private void btnVerInventarioBalcon_Click(object sender, EventArgs e)
        {
            //Query para obtener las reservas enlazadas con los id de los clientes en su respectiva tabla
            string obtenerReservas = "select * from inventariobalcon";
            MySqlDataReader reader = null;
            MySqlConnection conexionBD = mysql.conexion.Conexion();
            conexionBD.Open();
            //Contador que sera el puntero para el numero de fila en la que se ira insertando la data de la BD
            int contador = 0;
            //Limpiamos el datagrid
            DgbInventarioBalcon.Rows.Clear();
            DgbInventarioBalcon.Refresh();
            try
            {
                MySqlCommand comand = new MySqlCommand(obtenerReservas, conexionBD);
                reader = comand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataGridViewRow row = (DataGridViewRow)DgbInventarioBalcon.Rows[contador].Clone();
                        row.Cells[0].Value = reader.GetString(1);
                        row.Cells[1].Value = reader.GetString(2);
                        row.Cells[2].Value = "$"+reader.GetString(3);
                        DgbInventarioBalcon.Rows.Add(row);
                        contador++;
                    }
                }
                else
                {
                    MessageBox.Show("Aun no hay objetos guardados.");

                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnGuardarObjetoCliente_Click(object sender, EventArgs e)
        {
            //Obtenemos el valor del input seleccionado
            string nombreCliente = CbxClientesInventarioClientes.GetItemText(CbxClientesInventarioClientes.SelectedItem);
            //Hacemos un split para obtener solamente la clave del cliente
            string[] obtenerClaveCliente = nombreCliente.Split('-');
            string idCliente = obtenerClaveCliente[0];
            string nombreObjetoCliente = TxtNombreObjetoCliente.Text;
            string cantidadObjetoCliente = TxtCantidadObjetoCliente.Text;
            if (CbxClientesInventarioClientes.SelectedIndex != -1 && nombreObjetoCliente != "" && cantidadObjetoCliente != "") {

                string query = "insert into inventarioclientes (nombreObjeto,cantidadObjeto,idCliente) values('" + nombreObjetoCliente + "','" + cantidadObjetoCliente + "','" + idCliente + "')";
                MySqlConnection conexionBD = mysql.conexion.Conexion();
                conexionBD.Open();

                try
                {
                    MySqlCommand comando = new MySqlCommand(query, conexionBD);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Objeto guardado en el inventario del cliente.");
                } catch (MySqlException ex)
                {
                    MessageBox.Show("Error al guardar el objeto: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser llenados");
            }
        }

        private void BtnConsultarInventarioCliente_Click(object sender, EventArgs e)
        {
            MySqlDataReader reader = null;
            //Obtenemos el valor del input seleccionado
            string nombreCliente = CbxClientesInventarioClientes.GetItemText(CbxClientesInventarioClientes.SelectedItem);
            //Hacemos un split para obtener solamente la clave del cliente
            string[] obtenerClaveCliente = nombreCliente.Split('-');
            string idCliente = obtenerClaveCliente[0];
            string query = "select * from inventarioclientes where idCliente = '" + idCliente + "' ";
            int contador = 0;
            if (CbxClientesInventarioClientes.SelectedIndex != -1)
            {
                //Limpiamos el datagrid
                DgbInventarioCliente.Rows.Clear();
                DgbInventarioCliente.Refresh();

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
                            DataGridViewRow row = (DataGridViewRow)DgbInventarioCliente.Rows[contador].Clone();
                            row.Cells[0].Value = reader.GetString(1);
                            row.Cells[1].Value = reader.GetString(2);
                            row.Cells[2].Value = reader.GetString(4);
                            DgbInventarioCliente.Rows.Add(row);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El cliente aun no tiene inventario registrado");
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TpgReservaciones_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void DlgBalconDeChalita_Load(object sender, System.EventArgs e)
        {

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtSubTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private void CbxClientesInventarioClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}