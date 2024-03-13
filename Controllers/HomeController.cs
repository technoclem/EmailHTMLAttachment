using EmailHTMLAttachment.Models;
using EmailHTMLAttachment.Service;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmailHTMLAttachment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index(EmailModel em)
        {   
            if (ModelState.IsValid)
            {
                
                EmailService emailService = new EmailService();
                 bool response= await emailService.SendMail(em.EmailSubject, em.EmailBody,em.ReceiverEmail);
                if (response) TempData["success"] = "Email Sent Successfuly";
                else TempData["error"] = "Error sending Email";               
            }
            
            return View();
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
