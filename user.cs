using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace El_Balcon_de_Chalita
{
    public class user
    {
        public string usuario { get; set; }
        public int tipoUsuario { get; set; }

        public user()
        {
            usuario = "";
            tipoUsuario = -1;

        }
    }
}
