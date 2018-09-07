using Microsoft.AspNet.Identity;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace ProjectWebServer.Services
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            var msg = new SendGridMessage()
            {
                // should be a domain other than yahoo.com, outlook.com, hotmail.com, gmail.com
                From = new EmailAddress("donotreply@sit313mgmt.azurewebsites.net", "Task Management System"),
                Subject = message.Subject,
                PlainTextContent = message.Body,
                HtmlContent = message.Body
            };

            msg.AddTo(message.Destination);

            var apiKey = Environment.GetEnvironmentVariable("SendGridApiKey");      // This string is set on the Azure server
            var client = new SendGridClient(apiKey);

            // Create a Web transport for sending email.
            return client.SendEmailAsync(msg);
        }
    }
}