using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Balcon_de_Chalita
{
    class BuscaIndice
    {
        public int indiceCbxGenero(cliente cliente)
        {
            string[] generos = { "Masculino", "Femenino", "Otro" };
            for (int i = 0; i < 3; i++)
            {
                if (cliente.Genero == generos[i]) return i;
            }
            return -1;
        }
    }
}
