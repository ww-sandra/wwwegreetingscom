using System.ComponentModel.DataAnnotations;

namespace halloween.Models
{
    public class Contact
    {
        [Required(ErrorMessage = "Please fill in your name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name should be greater than 3 characters, and no more than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "This is not a valid email address!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Email should be at least 3 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Subject should be at least 3 characters")]
        public string Subject { get; set; }
  
        [Required(ErrorMessage = "Message is required")]
        [StringLength(600, MinimumLength = 3, ErrorMessage = "Message should be at least 3 characters")]
        public string Message { get; set; }

        public string Recaptcha { get; set; }

    }
}
