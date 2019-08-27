using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SendGrid.Helpers.Mail;
using SendGrid;

namespace APISendGrid
{
    class Program
    {
        static void Main(string[] args)
        {
            MailAsync().Wait();
        }

        
        static async Task MailAsync()
        {
            var apiKey = "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";           
            

            var cliente = new SendGridClient(apiKey);
            //cliente.

            var from = new EmailAddress("mccp1030@gmail.com");

            var asunto = "Prueba Correo";

            var to = new EmailAddress("mccamacho79@misena.edu.co");

            var contexto = "Prueba C#";

            var html = "<strong>Prueba ... 1</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to , asunto, contexto, html);
            var responde = await cliente.SendEmailAsync(msg);

        }
    }
}
