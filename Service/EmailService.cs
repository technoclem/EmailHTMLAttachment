


using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Net.Mail;
using System.Net;

namespace EmailHTMLAttachment.Service
{
    public class EmailService : IEmailService
    {
        private IWebHostEnvironment Environment;
        
        public EmailService(IWebHostEnvironment env)
        {
            Environment = env;
        }
        public async Task<string> GetHTMLTemplate(string subject, string body)
        {
            string EmailHtmlTemplate = "";
            try
            {
                // Construct the path to the template file inside the MailHTMLTemplate directory
                string templatePath = Path.Combine(Environment.WebRootPath,
                    "MailHTMLTemplate", "template.txt");

                // Read the content of the template file
                EmailHtmlTemplate = await File.ReadAllTextAsync(templatePath);
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

                MailMessage mm = new MailMessage("your sender email", receiver);
                mm.IsBodyHtml = true;
                mm.Subject = subject;
                mm.Body = await GetHTMLTemplate(subject, body);

                // I used gmail account for the smtp: provide your email smtp here
                var client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential("your sender email", "sender email password"),
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                client.Send(mm);
                response = true;
            }
            catch { }
           

            return response;
        }
    }
}
