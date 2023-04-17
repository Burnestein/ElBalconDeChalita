using System;

namespace El_Balcon_de_Chalita
{
    class generadorRandom
    {
        public int generarNumeroRandom()
        {
            //Instanciamos la clase Random para la creacion del codigo aleatorio del cliente
            Random rnd = new Random();
            //Guardamos un numero aleatorio en el rango de 1 a 10000 en una varable
            int random = rnd.Next(1, 10000);

            return random;
        }
    }
}
