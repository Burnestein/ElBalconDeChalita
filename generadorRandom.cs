using System;
using System.Text;

namespace El_Balcon_de_Chalita
{
    class generadorRandom
    {
        public int generarNumeroRandom()
        {
            //Instanciamos la clase Random para la creacion del codigo aleatorio del cliente
            Random rnd = new Random();
            //Guardamos un numero aleatorio en el rango de 1 a 10000 en una varable
            int random = rnd.Next(1000, 10000);

            return random;
        }

        public string GenerarCodigoAlfanumerico(int longitud)
        {
            const string caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            StringBuilder sb = new StringBuilder(longitud);

            for (int i = 0; i < longitud; i++)
            {
                int index = random.Next(caracteresPermitidos.Length);
                sb.Append(caracteresPermitidos[index]);
            }

            return sb.ToString();
        }

    }


}
