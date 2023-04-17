using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace El_Balcon_de_Chalita
{
    class correo
    {
        //Atributos
        public string nombreCorreo = "";
        //Funcion que manda un correo al correo del cliente que realizo la reserva
        //Para fines de prueba se utiliza el server SMTP de Mailtrap
        //@return void
        public void mandarCorreo()
        {
            //Instanciamos los correos emisor y receptor de la clase de MailAddress
            MailAddress para = new MailAddress(nombreCorreo);
            MailAddress de = new MailAddress("elbalcondechalita@hotmail.com");

            MailMessage mensaje = new MailMessage(de, para);
            mensaje.Subject = "Estimado cliente";
            mensaje.Body = "Estimado cliente , su reservación en el Balcón de Chalita se ha realizado con exito";
            //Ingresamos los parametros necesarios para acceder a nuesstro servidor SMTP
            SmtpClient client = new SmtpClient("smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("8f2a3a6c34898e", "77f26cbec5b6ed"),
                EnableSsl = true
            };

            try
            {
                //En caso de que todo salga bien se manda el correo al cliente
                client.Send(mensaje);
            }
            catch (SmtpException ex)
            {
                //En caso de que ocurra un error a nivel del servidor SMTP se notificara
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
