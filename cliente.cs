

namespace El_Balcon_de_Chalita
{
    class cliente : crud
    {
        public void asignarTablaConsulta(string tabla)
        {
            tablaConsulta = tabla;
        }

        public void asignarQueryEliminar(string query)
        {
            queryEliminar = query;
        }
       
    }
}
