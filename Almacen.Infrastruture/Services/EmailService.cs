using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace Almacen.Infrastructure.Services
{
    public class EmailService
    {
        private readonly SmtpClient _smtpClient;

        public EmailService()
        {
         _smtpClient = new SmtpClient("smtp-mail.outlook.com") 
            {
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                // Aca se pone el password de cada uno
                Credentials = new NetworkCredential("jonhanchia@hotmail.com", "Redbull1."), 
                EnableSsl = true 
            };
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var message = new MailMessage("jonhanchia@hotmail.com", to, subject, body)
            {
                IsBodyHtml = true 
            };

            await _smtpClient.SendMailAsync(message);
        }
    }
}