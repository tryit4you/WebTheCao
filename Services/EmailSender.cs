using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace WebTheCao.Services
{
    public  class EmailSender
    {
      
        public async static void SendMail(string email, string confirmationLink)
        {

            var smtpClient = new SmtpClient
            {
                Host = "mail.nopthegiare.com", // set your SMTP server name here
                Port = 25, // Port
                EnableSsl = false,
                Credentials = new NetworkCredential("admin@nopthegiare.com", "hung!@1997")
            };

            using (var mess = new MailMessage("admin@nopthegiare.com", email)
            {
                Subject = "Xác thực email từ https://nopthegiare.com",
                Body = confirmationLink
            })
            {
                await smtpClient.SendMailAsync(mess);
            }
        }
    }
}