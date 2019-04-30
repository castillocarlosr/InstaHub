using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaHub_MVC.Models
{
    public class EmailSender : IEmailSender
    {
        private IConfiguration _configuration;

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            SendGridClient client = new SendGridClient(_configuration["Sendgrid_Api_Key"]);

            SendGridMessage msg = new SendGridMessage();

            msg.SetFrom("noreply@InstaHub.com", "InstaHub Chat Place");

            msg.AddTo(email);
            msg.SetSubject("Welcome to InstaHub");
            msg.AddContent(MimeType.Html, htmlMessage);

            await client.SendEmailAsync(msg);
        }

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
