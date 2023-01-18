using Portfolio.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Portfolio.Servicios
{
    //clase para el servicio de envio de email
    public interface IservicioEmail
    {
        Task Enviar(ContactoViewModel contacto);
    }

    public class ServicioEmailSendGrid:IservicioEmail
    {
        private readonly IConfiguration configuration;

        public ServicioEmailSendGrid(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task Enviar (ContactoViewModel contacto)
        {
            var apiKey = configuration.GetValue<string>("SENDGRID_API_KEY");
            var email = configuration.GetValue<string>("SENDGRID_FROM");
            var nombre = configuration.GetValue<string>("SENDGRID_NOMBRE");

            var cliente = new SendGridClient(apiKey);
            var from = new EmailAddress(email,nombre);
            var subject = $"El cliente {contacto.Email} quiere contactarte";
            var to = new EmailAddress(email,nombre);
            var mensajeTextoPLano = contacto.Mensaje;
            var contenidoHtml= $@"De: {contacto.Nombre} - 
                               Email: {contacto.Email} - Mensaje: {contacto.Mensaje}";
            var singleEmail = MailHelper.CreateSingleEmail(from, to, subject, mensajeTextoPLano, contenidoHtml);
            var respuesta = await cliente.SendEmailAsync(singleEmail);
        }

    }
}
