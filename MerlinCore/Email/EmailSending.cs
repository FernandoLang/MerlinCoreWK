using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;
using Console = Colorful.Console;
using System.Drawing;

namespace MerlinCore
{
    class EmailSending
    {
        //--------------------------------------------------------------------------------
        SmtpClient client = new SmtpClient();
        NetworkCredential credential = new NetworkCredential();
        //--------------------------------------------------------------------------------
        public void Email()
        {
            try
            {
            //-----------------------------------------------------
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            credential.UserName = "merlin.kingwasp";
            credential.Password = "Kingwasp4500";
            client.Credentials = credential;
            //-----------------------------------------------------
            MailMessage message = new MailMessage();
            message.From = new MailAddress("merlin.kingwasp@gmail.com");
            Console.WriteLine("Digite o título do Email:", Color.BlueViolet);
            message.Subject = Console.ReadLine();
            Console.WriteLine("Digite o corpo da Mensagem:", Color.BlueViolet);
            message.Body = createBody(Console.ReadLine());
            message.IsBodyHtml = true;
            Console.WriteLine("Destinatário:");
            message.To.Add(Console.ReadLine());
            Console.WriteLine("Enviando Mensagem...", Color.BlueViolet);
            client.Send(message);
            Console.WriteLine("Mensagem Enviada", Color.BlueViolet);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao enviar a mensagem: " + ex.Message, Color.BlueViolet);
                
            }
        }
        //--------------------------------------------------------------------------------
        public string createBody(string message)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(@"../../../../MerlinCore/Email/Template.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{message}", message);
            return body;
        }
        //--------------------------------------------------------------------------------

    }

}
