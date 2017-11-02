using halloween.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Net.Mail;

namespace halloween.Pages
{
    public class PreviewModel : PageModel
    {
        public string Message { get; set; }

        public Contact Contact { get; set; }

        private BridgeDbContext _context;

        public PreviewModel(BridgeDbContext context)
        {
            _context = context;

        }

        public IActionResult OnGet(int id = 0)
        {
            if (id > 0)
            {
                Contact = _context.Contact.Find(id);
            }
            else
            {
                return Redirect("/");
            }


            return Page();


        }

        public IActionResult OnPost(int id = 0)
        {
            if (id > 0)
            {
                Contact = _context.Contact.Find(id);
                try
                {
                    //SEND MESSAGE
                    MailMessage message = new MailMessage();
                    message.Subject = "[Scary e-Greetings] " + Contact.Subject;
                    message.To.Add(new MailAddress(Contact.Email, Contact.Name));
                    message.From = new MailAddress("sandra@westsidewebsites.com", "Sandra");
                    message.IsBodyHtml = true;
                    var body = "<html>" +
                        "<head><title>Scary Greeting</title></head>" +
                        "<body>" +
                        ""
                    message.Body = Contact.Message;
                    using (var client = new SmtpClient())
                    {
                        //client.Host = "smtp.wowoco.org";
                        client.EnableSsl = true;
                        client.Host = "smtp17.bamtools.com";
                        client.Port = 2525;
                        client.UseDefaultCredentials = false;
                        client.Send(message);

                    }

                    return RedirectToPage("Confirm");
                } catch {

                    Message = "There was an error sending your message :(";
                }

            }

            return Page();
        }
    }
}
