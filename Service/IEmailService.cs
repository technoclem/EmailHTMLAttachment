namespace EmailHTMLAttachment.Service
{
    public interface IEmailService
    {
        Task<string> GetHTMLTemplate(string subject, string body);
        Task<bool> SendMail(string subject, string body,string receiver);
    }
}
