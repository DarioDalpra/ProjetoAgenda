using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda_WEB.Utils
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<EmailAuthOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public EmailAuthOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(List<string> emails, string subject, string message)
        {
            return Execute("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", subject, message, emails);
        }

        public Task Execute(string apiKey, string subject, string message, List<string> emails)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("dariodalpra@gmail.com", "AGENDA_MEDICA_WEB"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            foreach (var email in emails)
            {
                msg.AddTo(new EmailAddress(email));
            }

            Task response = client.SendEmailAsync(msg);
            return response;
        }
    }
}