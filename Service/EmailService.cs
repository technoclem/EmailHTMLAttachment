using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;

namespace EmailHTMLAttachment.Service
{
    // Service responsible for sending emails with HTML content and attachments
    public class EmailService : IEmailService
    {
        private IWebHostEnvironment _environment; // Environment details
        private readonly IConfiguration _config; // Application configuration
        private readonly ILogger<EmailService> _logger; // Logging service

        // Constructor to initialize dependencies
        public EmailService(IWebHostEnvironment environment, IConfiguration config, ILogger<EmailService> logger)
        {
            _environment = environment;
            _config = config;
            _logger = logger;
        }

        // Method to retrieve HTML email template
        public async Task<string> GetHTMLTemplate(string subject, string body)
        {
            string EmailHtmlTemplate = "";
            try
            {
                // Construct the path to the template file inside the Helper directory
                string templatePath = Path.Combine(_environment.ContentRootPath, "Helper", "EmailTemplate.txt");

                // Read the content of the template file
                EmailHtmlTemplate = await File.ReadAllTextAsync(templatePath);
                EmailHtmlTemplate = EmailHtmlTemplate.Replace("***SUBJECT***", subject);
                EmailHtmlTemplate = EmailHtmlTemplate.Replace("***CONTENT***", body);

            }
            catch (Exception ex)
            {
                // Log error if unable to read template
                _logger.LogError(ex, "Unable to read the Email HTML Template");
            }
            return EmailHtmlTemplate;
        }

        // Method to send email
        public async Task<bool> SendMail(string subject, string body, IFormFile attachment, string receiver)
{
    bool response = false;
    try
    {
        // Retrieve sender email and password from configuration
        string? senderEmail = _config.GetValue<string>("Email:SenderEmail");
        string? senderPassword = _config.GetValue<string>("Email:SenderPassword");

        // Proceed if sender credentials are available
        if (!string.IsNullOrEmpty(senderEmail) && !string.IsNullOrEmpty(senderPassword))
        {
            // Create mail message
            using (MailMessage mm = new MailMessage(senderEmail, receiver))
            {
                mm.IsBodyHtml = true;
                mm.Subject = subject;
                mm.Body = await GetHTMLTemplate(subject, body);

                // Attach the file if not null
                if (attachment != null)
                {
                    using (var ms = new MemoryStream())
                    {
                        await attachment.CopyToAsync(ms);
                        ms.Seek(0, SeekOrigin.Begin);
                        // Reset the position to the beginning of the stream before attaching
                        mm.Attachments.Add(new Attachment(ms, attachment.FileName));
                    }
                }

                // Setup SMTP client (Gmail in this case)
                using (var client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.Credentials = new NetworkCredential(senderEmail, senderPassword);
                    client.EnableSsl = true;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    // Send email
                    await client.SendMailAsync(mm);
                }
            }
            response = true;
        }
        else
        {
            // Log error if sender configuration is missing
            _logger.LogError("Unable to read the Email Configuration in appsettings");
        }
    }
    catch (Exception ex)
    {
        // Log error if unable to send email
        _logger.LogError(ex, $"Unable to send message to {receiver}");
    }
    return response;
}



    }
}
