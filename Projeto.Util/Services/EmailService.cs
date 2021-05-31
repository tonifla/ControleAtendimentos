using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Util.Models;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace Projeto.Util.Services
{
    public class EmailService
    {
        public void SendMessage(EmailModel model)
        {
            var conta = ConfigurationManager.AppSettings["CONTA"];
            var senha = ConfigurationManager.AppSettings["SENHA"];
            var smtp = ConfigurationManager.AppSettings["SMTP"];
            var porta = ConfigurationManager.AppSettings["PORTA"];

            MailMessage mail = new MailMessage(conta, model.EmailTo);
            mail.Subject = model.Subject;
            mail.Body = model.Body;
            mail.IsBodyHtml = model.IsBodyHtml;

            SmtpClient client = new SmtpClient(smtp, int.Parse(porta));
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(conta, senha);

            //Acesso a app menos seguro
            //https://myaccount.google.com/lesssecureapps
            client.Send(mail);
        }
    }
}
