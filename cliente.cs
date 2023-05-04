

namespace El_Balcon_de_Chalita
{
    public class cliente : crud
    {
        private int idCliente;
        private string nombre;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private string numCelular;
        private string email;
        private string codigoCliente;
        private string genero;
        private string lugarProcedencia;
        private string estadoCivil;
        private string fechaNacimiento;
        public string nombreCompleto { get; set; }

        public cliente()
        {
            idCliente = -1;
            nombre = "";
            apellidoPaterno = "";
            apellidoMaterno = "";
            numCelular = "";
            email = "";
            codigoCliente = "";
            genero = "";
            lugarProcedencia = "";
            estadoCivil = "";
            fechaNacimiento = "";
            nombreCompleto = "";
        }
        public void asignarTablaConsulta(string tabla)
        {
            tablaConsulta = tabla;
        }

        public void asignarQueryEliminar(string query)
        {
            queryEliminar = query;
        }

        public int IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string ApellidoPaterno
        {
            get { return apellidoPaterno; }
            set { apellidoPaterno = value; }
        }

        public string ApellidoMaterno
        {
            get { return apellidoMaterno; }
            set { apellidoMaterno = value; }
        }

        public string NumCelular
        {
            get { return numCelular; }
            set { numCelular = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string CodigoCliente
        {
            get { return codigoCliente; }
            set { codigoCliente = value; }
        }

        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }

        public string LugarProcedencia
        {
            get { return lugarProcedencia; }
            set { lugarProcedencia = value; }
        }

        public string EstadoCivil
        {
            get { return estadoCivil; }
            set { estadoCivil = value; }
        }

        public string FechaNacimiento
        {
            get { return fechaNacimiento; }
            set { fechaNacimiento = value; }
        }

    }
}
