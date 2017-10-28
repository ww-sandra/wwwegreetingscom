using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace halloween.Models
{
    public class Contact
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please fill in your name")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name should be at least 3 characters, and maximum of 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "This is not a valid email address!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Email should be at least 3 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "Subject should be at least 3 characters")]
        public string Subject { get; set; }
  
        [Required(ErrorMessage = "Message is required, duummy")]
        [StringLength(600, MinimumLength = 3, ErrorMessage = "Message should be at least 3 characters")]
        public string Message { get; set; }

        [RegularExpression("/false/", ErrorMessage = "You must agree to terms to send!")]
        public string Terms { get; set; }

        [NotMapped]
        public DateTime Date { get; set; }

        [NotMapped]
        public string Recaptcha { get; set; }

    }
}
