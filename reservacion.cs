using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Balcon_de_Chalita
{
    public class reservacion
    {
        public cliente cliente;
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
        public string horaEntrada { get; set; }
        public string horaSalida { get; set; }

        public reservacion()
        {
            cliente micliente = new cliente();
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
            horaEntrada = "";
            horaSalida = "";
        }

        public void limpiarAtributos()
        {
            cliente micliente = new cliente();
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
            horaEntrada = "";
            horaSalida = "";
        }

    }
}
