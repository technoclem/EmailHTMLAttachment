


using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Net.Mail;
using System.Net;

namespace EmailHTMLAttachment.Service
{
    public class EmailService : IEmailService
    {
        public async Task<string> GetHTMLTemplate(string subject, string body)
        {
            string EmailHtmlTemplate = "";
            try
            {
                // Construct the path to the template file inside the MailHTMLTemplate directory
               string templatePath = Path.Combine(Directory.GetCurrentDirectory(), 
                   "MailHTMLTemplate", "template.txt");

                // Read the content of the template file
                string htmlTemplate = await File.ReadAllTextAsync(templatePath);
                EmailHtmlTemplate = EmailHtmlTemplate.Replace("***SUBJECT***", subject);
                EmailHtmlTemplate = EmailHtmlTemplate.Replace("***CONTENT***", body);
               
            }
            catch { }
            return EmailHtmlTemplate;
        }

        public async Task<bool> SendMail(string subject, string body, string receiver)
        {
            bool response =false;

            try
            {
                MailMessage mm = new MailMessage("clementomolayo.net@gmail.com", receiver);
                mm.IsBodyHtml = true;
                mm.Subject = subject;
                mm.Body = await GetHTMLTemplate(subject, body);
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("clementomolayo.net@gmail.com", "bakfkpxqnseaisjn"),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                client.Send(mm);
               response=true;
            }
            catch  {  }

            return response;
        }
    }
}
