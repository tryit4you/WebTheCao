using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WebTheCao.Areas.Admin.Services
{
    public class EmailSender
    {
        public async static void SendMail(string email, string message,string subject)
        {

            var smtpClient = new SmtpClient
            {
                Host = "smtp.gmail.com", // set your SMTP server name here
                Port = 587, // Port
                EnableSsl = true,
                Credentials = new NetworkCredential("nopthegiare2018@gmail.com", "baotramcuaba2018")
            };

            using (var mess = new MailMessage( email, "nopthegiare2018@gmail.com")
            {
                Subject = subject,
                Body = message,
                IsBodyHtml=true
            })
            {
                await smtpClient.SendMailAsync(mess);
            }
        }
    }
}
