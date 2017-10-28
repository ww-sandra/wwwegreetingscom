using halloween.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace halloween.Pages
{
    public class ConfirmModel : PageModel
    {
        public string Message { get; set; }

        public Contact Contact { get; set; }

        private BridgeDbContext _context;

        public ConfirmModel(BridgeDbContext context)
        {
            _context = context;

        }

        public void OnGet(int id=0)
        {
            if(id > 0)
            {
                Contact = _context.Contact.Find(id);
            }
            
        }

        public void OnPost(int id = 0)
        {
            if (id > 0)
            {
                Contact = _context.Contact.Find(id);

                //SEND MESSAGE
                //MailMessage message = new MailMessage();
                //message.Subject = "[Wonder Women Coders] " + Contact.Subject;
                //message.To.Add(new MailAddress(Contact.Email, Contact.Name));
                //message.From = new MailAddress("sender170802@mail02.wonderwomencoders.com", "Wonder Women Coders");
                //message.IsBodyHtml = true;

                //message.Body = Contact.Message;
                //using (var client = new SmtpClient())
                //{
                //    client.Host = "mail02.wonderwomencoders.com";
                //    client.Port = 25;
                //    var credentials = new NetworkCredential("sender170802@mail02.wonderwomencoders.com", "Got2code!");
                //    client.UseDefaultCredentials = false;
                //    client.Credentials = credentials;
                //    client.Send(message);

                //}

            //return RedirectToPage("index");

            }

        }
    }
}
