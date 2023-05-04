
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Net;
using System.Net.Mail;
using System.Collections.Generic;
using System.Drawing;

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
        private int idCliente = -1;
        private string correoCliente = "";
        private double totalReserva = 0;
        private string idCompañia = "";
        private int selectorContexto; // Determina en qué pestaña se encuentra el usuario.
                                          // 0-Clientes 1-Reservaciones 2-Inventario 3-InventarioClientes 
        private cliente micliente;
        private consulta miconsulta;
        private reservacion mireservacion;

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
            selectorContexto = 0;
            CbxClientes.Visible = false;
            tsbQuitarCliente.Visible = false;
            TsbConsultar.Visible = false;
            micliente = new cliente();
            miconsulta = new consulta();
            mireservacion = new reservacion();
            //Generamos el codigo en automatico del cliente
            generarCodigoCliente();
            //Llenamos los combobox de los clientes y compañias afiliadas
            llenarComboBoxClientes();
            llenarComboBoxCompañiasAfiliadas();
            //this.micliente = micliente;
            tsbSeleccionar.Visible = true;
            tsbSeleccionar.Enabled = false;
            TsbNuevo.Visible = true;
            TsbNuevo.Enabled = true;
            TsbGuardar.Visible = true;
            TsbGuardar.Enabled = true;
            TsbEliminar.Visible = true;
            TsbEliminar.Enabled = true;

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
            DialogResult result = MessageBox.Show("Crear un nuevo registro borrará toda la información del formulario. ¿Estás seguro que quieres continuar?", "Crear Nuevo", MessageBoxButtons.OKCancel);
            // Verificar la respuesta del usuario
            if (result == DialogResult.OK)
            {
                // El usuario ha seleccionado "Aceptar"
                // Realizar la acción deseada
                limpiarCamposCliente();
                limpiarCamposReservaciones();
                limpiarCamposFormInventario();
            }
            else
            {
                // El usuario ha seleccionado "Cancelar"
                // Cancelar la acción o realizar otra acción según sea necesario
            }
            
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
            limpiarCamposCliente();
        }

        //---------------------------------------------------------------------
        //Funcion que inserta cliente en la BD
        //--
        private void TsbGuardar_Click(object sender, System.EventArgs e)
        {
            switch (selectorContexto)
            {
                case 0: // La pestaña de Clientes está seleccionada
                    guardarClienteBD();
                    break;
                case 1: // La pestaña de Reservaciones está seleccionada
                    guardarReservaBD();
                    break;
                case 2: // La pestaña de Inventario esta seleccionada
                    guardarObjetoBD();
                    break;
                case 3: // La pestaña de Inventario de Cliente esta seleccionada
                    guardarObjetoClienteBD();
                    break;
                default:
                    MessageBox.Show("Error con el selector de contexto.");
                    break;
            }
            
        }
        
        private void guardarClienteBD() // Realiza la insercion del cliente en la BD
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
                            CbxClientes.Items.Add(codigo + "-" + nombre);
                            CbxClientesInventarioClientes.Items.Add(codigo + "-" + nombre);
                            //Ejecutamos funcion para limpiar los campos
                            limpiarCamposCliente();

                        }
                        //Cacha alguna excepcion en la insecion de la bd
                        catch (MySqlException ex)

                        {
                            //MessageBox.Show("Error durante la insercion del registro: " + ex.Message);
                            //Si no puede guardar intenta editar el registro

                            DialogResult result = MessageBox.Show("Ya extiste un registro con éste código. ¿Desea sobre escribirlo?", "Actualizar Datos", MessageBoxButtons.OKCancel);
                            // Verificar la respuesta del usuario
                            if (result == DialogResult.OK)
                            {
                                // El usuario ha seleccionado "Aceptar"
                                // Realizar la acción deseada
                                actualizarRegistro();
                            }
                            else
                            {
                                // El usuario ha seleccionado "Cancelar"
                                // Cancelar la acción o realizar otra acción según sea necesario
                            }
                            
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
        private void limpiarCamposCliente()
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

            tslCliente.Text = "Cliente:";
            tstbBuscarCliente.Text = "";

        }

        private void limpiarCamposReservaciones()
        {
            txtTotal.Text = "";
            cbxCompañias.SelectedIndex = -1;
            txtSubTotal.Text = "";
            DgbReservaciones.Rows.Clear();
        }

        public void LlenarFormulario(cliente micliente)
        {
            tslCliente.Text = "Cliente: " + micliente.Nombre + " " + micliente.ApellidoPaterno + " " + micliente.ApellidoMaterno;
            TbxCodigo.Text = micliente.CodigoCliente;
            TbxNombre.Text = micliente.Nombre;
            TbxApellidoP.Text = micliente.ApellidoPaterno;
            TbxApellidoM.Text = micliente.ApellidoMaterno;
            TbxCorreo.Text = micliente.Email;
            TbxLugarProcedencia.Text = micliente.LugarProcedencia;
            TbxTelefonoMovil.Text = micliente.NumCelular;

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
        
        public void ActualizarForm()
        {
            limpiarCamposCliente();
            limpiarCamposReservaciones();
            limpiarCamposFormInventario();
            
            LlenarFormulario(micliente);
            idCliente = micliente.IdCliente;
            correoCliente = micliente.Email;
            dgvMaster.DataSource = null;
            dgvMaster.Rows.Clear();
            dgvMaster.Refresh();
        }
        private void TsbActualizar_Click(object sender, EventArgs e)
        {
            actualizarRegistro();
        }
        private void actualizarRegistro()
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
                    limpiarCamposCliente();

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

            /*
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

            */


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
            /*
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
            */
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
            guardarReservaBD();
        }

        private void guardarReservaBD() //realiza la insercion de la reserva en la BD
        {
            //En caso de que todos los campos rqueridos sean llenados se procede a guardar la reserva
            if (idCliente != -1 && fechaEntrada != "" && fechaSalida != "" && cbxCompañias.SelectedIndex != -1)
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
            limpiarTabla();
            dgvMaster.Columns.Add("IdReservaciones", "IdReservaciones");
            dgvMaster.Columns.Add("Cliente", "Cliente");
            dgvMaster.Columns.Add("Fecha de Entrada", "Fecha de Entrada");
            dgvMaster.Columns.Add("Fecha de Salida", "Fecha de Salida");
            if (micliente.IdCliente >= 0) { // revisa el id del cliente seleccionado
                miconsulta.ConsultarReservaciones(dgvMaster, micliente); // si esta seleccionado busca reservas del cliente
            } else miconsulta.ConsultarReservaciones(dgvMaster); 

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
            guardarObjetoBD();
        }

        private void guardarObjetoBD()
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

                    DgbInventarioBalcon.Rows.Add(nombreObjeto, cantidad, precio);

                }
                catch (MySqlException ex)
                {
                    //MessageBox.Show("Ocurrio un error insertando el elemento:" + ex.Message);
                    DialogResult result = MessageBox.Show("Ya extiste un registro de este artículo. ¿Desea sobre escribirlo?", "Actualizar Datos", MessageBoxButtons.OKCancel);
                    // Verificar la respuesta del usuario
                    if (result == DialogResult.OK)
                    {
                        // El usuario ha seleccionado "Aceptar"
                        // Realizar la acción deseada
                        editarObjetoBD();
                    }
                    else
                    {
                        // El usuario ha seleccionado "Cancelar"
                        // Cancelar la acción o realizar otra acción según sea necesario
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Debe llenar todos los campos");
            }
        }

        private void btnConsultarObjeto_Click(object sender, EventArgs e)
        {
            limpiarTabla();
            dgvMaster.Columns.Add("nombreObjeto", "Articulo");
            dgvMaster.Columns.Add("cantidadObjeto", "Cantidad");
            dgvMaster.Columns.Add("precioObjeto", "Precio Unitario");
            miconsulta.consultarInventario(dgvMaster, txtNombreObjeto.Text, txtCantidadObjeto.Text);

        }

        private void btnEditarObjeto_Click(object sender, EventArgs e)
        {
            editarObjetoBD();
        }
        private void editarObjetoBD()
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
                dgvMaster.Refresh();
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
            DgbInventarioBalcon.Rows.Clear();
            DgbInventarioCliente.Rows.Clear();
            TxtNombreObjetoCliente.Text = "";
            TxtCantidadObjetoCliente.Text = "";
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
                        row.Cells[2].Value = "$" + reader.GetString(3);
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
            guardarObjetoClienteBD();
        }

        private void guardarObjetoClienteBD() // Realiza la insercion del objeto del cliente en BD
        {
            //Obtenemos el valor del input seleccionado
            //string nombreCliente = CbxClientesInventarioClientes.GetItemText(CbxClientesInventarioClientes.SelectedItem);
            //Hacemos un split para obtener solamente la clave del cliente
            //string[] obtenerClaveCliente = nombreCliente.Split('-');
            //string idCliente = obtenerClaveCliente[0];
            string nombreObjetoCliente = TxtNombreObjetoCliente.Text;
            string cantidadObjetoCliente = TxtCantidadObjetoCliente.Text;

            if (idCliente > -1 && nombreObjetoCliente != "" && cantidadObjetoCliente != "")
            {
                DialogResult result = MessageBox.Show("¿Desea guardar este articulo?", "Guardar Objeto de Cliente", MessageBoxButtons.OKCancel);
                // Verificar la respuesta del usuario
                if (result == DialogResult.OK)
                {
                    string query = "insert into inventarioclientes (nombreObjeto,cantidadObjeto,idCliente) values('" + nombreObjetoCliente + "','" + cantidadObjetoCliente + "','" + idCliente + "')";
                    MySqlConnection conexionBD = mysql.conexion.Conexion();
                    conexionBD.Open();

                    try
                    {
                        MySqlCommand comando = new MySqlCommand(query, conexionBD);
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Objeto guardado en el inventario del cliente.");
                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error al guardar el objeto: " + ex.Message);
                    }
                }
                else
                {
                    // El usuario ha seleccionado "Cancelar"
                    // Cancelar la acción o realizar otra acción según sea necesario
                }
                
            }
            else
            {
                MessageBox.Show("Todos los campos deben ser llenados");
            }
        }

        private void BtnConsultarInventarioCliente_Click(object sender, EventArgs e)
        {
            limpiarTabla();
            dgvMaster.Columns.Add("nombreObjeto", "Articulo");
            dgvMaster.Columns.Add("cantidadObjeto", "Cantidad");
            dgvMaster.Columns.Add("fechaRegistro", "Fecha de Registro");
            miconsulta.consultarInventarioClientes(dgvMaster, micliente);
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


        public string Busqueda
        {
            get { return tstbBuscarCliente.Text; }
        }

        public cliente MiCliente
        {
            get { return micliente; }
            set { micliente = value; }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            quitarCliente();
        }

        public void quitarCliente()
        {
            micliente = new cliente();
            micliente.IdCliente = -1;
            ActualizarForm();
        }

        private void tslCliente_TextChanged(object sender, EventArgs e)
        {
            if (micliente.IdCliente > -1)
            {
                tsbQuitarCliente.Visible = true;
            }

            else
            {
                tsbQuitarCliente.Visible = false;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void tsbBuscarCliente_Click(object sender, EventArgs e)
        {
            limpiarTabla();
            //busquedaclientes ventanabusqueda = new busquedaclientes(micliente);
            //ventanabusqueda.dlgbalcon = this;
            string busqueda = tstbBuscarCliente.Text;
            //ventanabusqueda.buscarClientes(busqueda);
            //ventanabusqueda.Show();


            dgvMaster.DataSource = miconsulta.ConsultarClientes(busqueda);

        }

        private void btnConsultarReservasAll_Click(object sender, EventArgs e)
        {
            limpiarTabla();
            dgvMaster.Columns.Add("IdReservaciones", "IdReservaciones");
            dgvMaster.Columns.Add("Cliente", "Cliente");
            dgvMaster.Columns.Add("Fecha de Entrada", "Fecha de Entrada");
            dgvMaster.Columns.Add("Fecha de Salida", "Fecha de Salida");
            miconsulta.ConsultarReservaciones(dgvMaster);
        }


        private void TbcPrincipal_SelectedIndexChanged(object sender, EventArgs e) // Cambia el selector de contexto dependiendo la pestaña abierta
        {
            limpiarTabla();
            selectorContexto = TbcPrincipal.SelectedIndex;
            if (selectorContexto == 2) selectorContexto = TbcInventarioBalcon.SelectedIndex + 2; // Si la pestaña de inventario esta seleccionada se le suman las otras dos que tiene adentro.
            selectorContextoAcciones(selectorContexto);
        }

        private void TbcInventarioBalcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            limpiarTabla();
            selectorContexto = TbcPrincipal.SelectedIndex;
            if (selectorContexto == 2) selectorContexto = TbcInventarioBalcon.SelectedIndex + 2; // Si la pestaña de inventario esta seleccionada se le suman las otras dos que tiene adentro.
            selectorContextoAcciones(selectorContexto);
        }

        private void selectorContextoAcciones(int selector)
        {
            switch (selector) // 0-Clientes 1-Reservaciones 2-Inventario 3-InventarioClientes 
            {
                case 0:
                    tsbSeleccionar.Visible = true;
                    tsbSeleccionar.Enabled = false;
                    TsbNuevo.Visible = true;
                    TsbNuevo.Enabled = true;
                    TsbGuardar.Visible = true;
                    TsbGuardar.Enabled = true;
                    TsbEliminar.Visible = true;
                    TsbEliminar.Enabled = true;

                    break;
                case 1:
                    tsbSeleccionar.Visible = false;
                    tsbSeleccionar.Enabled = false;
                    TsbNuevo.Visible = true;
                    TsbNuevo.Enabled = true;
                    TsbGuardar.Visible = true;
                    TsbGuardar.Enabled = true;
                    TsbEliminar.Visible = true;
                    TsbEliminar.Enabled = false;
                    break;
                case 2:
                    tsbSeleccionar.Visible = false;
                    tsbSeleccionar.Enabled = false;
                    TsbNuevo.Visible = true;
                    TsbNuevo.Enabled = true;
                    TsbGuardar.Visible = true;
                    TsbGuardar.Enabled = true;
                    TsbEliminar.Visible = true;
                    TsbEliminar.Enabled = false;
                    break;
                case 3:
                    tsbSeleccionar.Visible = false;
                    tsbSeleccionar.Enabled = false;
                    TsbNuevo.Visible = true;
                    TsbNuevo.Enabled = true;
                    TsbGuardar.Visible = true;
                    TsbGuardar.Enabled = true;
                    TsbEliminar.Visible = true;
                    TsbEliminar.Enabled = false;
                    break;
                default:
                    tsbSeleccionar.Visible = true;
                    tsbSeleccionar.Enabled = false;
                    TsbNuevo.Visible = true;
                    TsbNuevo.Enabled = false;
                    TsbGuardar.Visible = true;
                    TsbGuardar.Enabled = false;
                    TsbEliminar.Visible = true;
                    TsbEliminar.Enabled = false;
                    break;
            }
        }

        private void dgvMaster_SelectionChanged(object sender, EventArgs e) //Se acciona al seleccionar una fila en la tabla
        {
            int seleccion = dgvMaster.CurrentCell.RowIndex;
            if (dgvMaster.SelectedRows.Count == 1 && dgvMaster[0,seleccion].Value != null)
            {
                // Obtener la fila seleccionada
                switch (selectorContexto)
                {
                    case 0: // La pestaña de Clientes está seleccionada
                        tsbSeleccionar.Enabled = true;
                        tsbSeleccionar.BackColor = SystemColors.HotTrack;
                        tsbSeleccionar.ForeColor = Color.White;
                        break;
                    case 1: // La pestaña de Reservaciones está seleccionada
                        TsbEliminar.Enabled = true;
                        break;
                    case 2: // La pestaña de Inventario esta seleccionada
                        TsbEliminar.Enabled = true;
                        break;
                    case 3: // La pestaña de Inventario de Cliente esta seleccionada
                        TsbEliminar.Enabled = true;
                        break;
                    default:
                        MessageBox.Show("Error con el selector de contexto.");
                        break;
                }
                
            }
            else
            {
                switch (selectorContexto)
                {
                    case 0: // La pestaña de Clientes está seleccionada
                        tsbSeleccionar.Enabled = false;
                        tsbSeleccionar.BackColor = SystemColors.ControlLightLight;
                        tsbSeleccionar.ForeColor = SystemColors.ControlDark;
                        break;
                    case 1: // La pestaña de Reservaciones está seleccionada
                        TsbEliminar.Enabled = false;
                        break;
                    case 2: // La pestaña de Inventario esta seleccionada
                        TsbEliminar.Enabled = false;
                        break;
                    case 3: // La pestaña de Inventario de Cliente esta seleccionada
                        TsbEliminar.Enabled = false;
                        break;
                    default:
                        MessageBox.Show("Error con el selector de contexto.");
                        break;
                }
                
            }
        }

        private void tsbSeleccionar_Click(object sender, EventArgs e)
        {
            switch (selectorContexto)
            {
                case 0: // La pestaña de Clientes está seleccionada
                    seleccionarCliente();
                    break;
                case 1: // La pestaña de Reservaciones está seleccionada
                    
                    break;
                case 2: // La pestaña de Inventario esta seleccionada
                    
                    break;
                case 3: // La pestaña de Inventario de Cliente esta seleccionada
                    
                    break;
                default:
                    MessageBox.Show("Error con el selector de contexto.");
                    break;
            }
            
        }
        private void seleccionarCliente()
        {
            int selectedIndex = dgvMaster.CurrentCell.RowIndex;
            micliente.IdCliente = Convert.ToInt32(dgvMaster[0, selectedIndex].Value);
            micliente.Nombre = dgvMaster[1, selectedIndex].Value.ToString();
            micliente.ApellidoPaterno = dgvMaster[2, selectedIndex].Value.ToString();
            micliente.ApellidoMaterno = dgvMaster[3, selectedIndex].Value.ToString();
            micliente.NumCelular = dgvMaster[4, selectedIndex].Value.ToString();
            micliente.Email = dgvMaster[5, selectedIndex].Value.ToString();
            micliente.CodigoCliente = dgvMaster[6, selectedIndex].Value.ToString();
            micliente.Genero = dgvMaster[7, selectedIndex].Value.ToString();
            micliente.LugarProcedencia = dgvMaster[8, selectedIndex].Value.ToString();
            micliente.EstadoCivil = dgvMaster[9, selectedIndex].Value.ToString();
            micliente.FechaNacimiento = dgvMaster[10, selectedIndex].Value.ToString();
            ActualizarForm();
        }
        private void seleccionarReserva()
        {
            
            int selectedIndex = dgvMaster.CurrentCell.RowIndex;
            mireservacion.id = Convert.ToInt32(dgvMaster[0, selectedIndex].Value);
            mireservacion.cliente.nombreCompleto = dgvMaster[1, selectedIndex].Value.ToString();
            mireservacion.horaEntrada = dgvMaster[2, selectedIndex].Value.ToString();
            mireservacion.horaSalida = dgvMaster[3, selectedIndex].Value.ToString();
        }
        private void limpiarTabla()
        {
            dgvMaster.DataSource = null;
            dgvMaster.Rows.Clear();
            dgvMaster.Columns.Clear();
        }
    }
}