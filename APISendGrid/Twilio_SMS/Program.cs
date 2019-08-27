using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;
namespace Twilio_SMS
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Las credenciales de prueba 
            /// solo le brindan una forma de "simular" enviar un mensaje o hacer una llamada telefónica. 
            /// Twilio no cargará su proyecto, ni se realizarán las acciones.

            TwilioClient.Init(
                Environment.GetEnvironmentVariable("TEST ACCOUNT SID"),
                Environment.GetEnvironmentVariable("TEST AUTHTOKEN")
                
                );

            MessageResource.Create(
                to: new PhoneNumber("+573222571199"),
                from: new PhoneNumber("+15005550006"),
                body: "Prueba"
                );
        }
    }
}
