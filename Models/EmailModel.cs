using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmailHTMLAttachment.Models
{
    public class EmailModel
    {


        [Required(ErrorMessage = "Receiver Email Address is required")]
        [DisplayName("Receiver Email Address")]
        [MaxLength(100, ErrorMessage = "Receiver Email Address must be at most 100 characters")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? ReceiverEmail { get; set; }

        [Required(ErrorMessage = "Subject of The Email is required")]
        [DisplayName("Subject of The Email")]
        [MaxLength(200, ErrorMessage = "Subject of The Email must be at most 200 characters")]
        public string? EmailSubject { get; set; }

        [Required(ErrorMessage = "Body of The Email is required")]
        [DisplayName("Body of The Email")]
        [MaxLength(1000, ErrorMessage = "Body of The Email must be at most 1000 characters")]
        public string? EmailBody { get; set;}
    }
}
