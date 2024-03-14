namespace EmailHTMLAttachment.Service
{
    // Interface defining methods for email service
    public interface IEmailService
    {
        Task<string> GetHTMLTemplate(string subject, string body); // Method to retrieve HTML email template
        Task<bool> SendMail(string subject, string body, string receiver); // Method to send email
    }
}
