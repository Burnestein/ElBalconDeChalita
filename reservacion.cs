using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Balcon_de_Chalita
{
    public class reservacion
    {
        public cliente micliente { get; set; }
        public int idReservacion { get; set; }
        public int entradaHora { get; set; }
        public int entradaMinuto { get; set; }
        public int entradaDia { get; set; }
        public int entradaMes { get; set; }
        public int entradaAño { get; set; }
        public int salidaHora { get; set; }
        public int salidaMinuto { get; set; }
        public int salidaDia { get; set; }
        public int salidaMes { get; set; }
        public int salidaAño { get; set; }
        public int id { get; set; }
        public string fechaEntrada { get; set; }
        public string fechaSalida { get; set; }
        public string compAfiliada { get; set; }

        public int idAfiliado { get; set; }

        public reservacion()
        {
            micliente = new cliente();
            idReservacion = -1;
            entradaHora = -1;
            entradaMinuto = -1;
            entradaDia = -1;
            entradaMes = -1;
            entradaAño = -1;
            salidaHora = -1;
            salidaMinuto = -1;
            salidaDia = -1;
            salidaMes = -1;
            salidaAño = -1;
            id = -1;
            fechaEntrada = "";
            fechaSalida = "";
            compAfiliada = "";
            idAfiliado = -1;
        }

        public void limpiarAtributos()
        {
            micliente = new cliente();
            entradaHora = -1;
            entradaMinuto = -1;
            entradaDia = -1;
            entradaMes = -1;
            entradaAño = -1;
            salidaHora = -1;
            salidaMinuto = -1;
            salidaMes = -1;
            salidaAño = -1;
            id = -1;
            fechaEntrada = "";
            fechaSalida = "";
        }
        public int separarAño(string fecha)
        {
            string año = fecha.Substring(0, 4);
            return Convert.ToInt32(año);
        }
        public int separarMes(string fecha)
        {
            string mes = fecha.Substring(5, 2);
            return Convert.ToInt32(mes);
        }
        public int separarDia(string fecha)
        {
            string dia = fecha.Substring(8, 2);
            return Convert.ToInt32(dia);
        }
    }
}
