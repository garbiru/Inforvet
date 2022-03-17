using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using MimeKit.Text;

namespace Inforvet.Services
{
    public class EmailSender : IEmailSender
    {
        // Our private configuration variables
        private string host;
        private int port;
        private bool enableSSL;
        private string userName;
        private string password;

        // Get our parameterized configuration
        public EmailSender(/*string host, int port, bool enableSSL, string userName, string password*/)
        {
            this.host = "smtp.gmail.com";
            this.port = 465;
            this.enableSSL = true;
            this.userName = "inforvet.pt";
            this.password = "inforvet1!";
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Inforvet", "inforvet.pt@gmail.com"));
            message.To.Add(new MailboxAddress(email, email));
            message.Subject = subject;
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = htmlMessage
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                await client.ConnectAsync(host, port, enableSSL);

                // Note: only needed if the SMTP server requires authentication
                await client.AuthenticateAsync(userName, password);

                await client.SendAsync(message);
                await client.DisconnectAsync(true);
            }
        }
    }
}