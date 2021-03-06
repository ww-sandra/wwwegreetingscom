﻿using halloween.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace halloween.Pages
{
    public class PreviewModel : PageModel
    {
        public string Message { get; set; }

        public Contact Contact { get; set; }

        private BridgeDbContext _context;
        private IConfiguration _configuration;

        public PreviewModel(BridgeDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

        }

        public IActionResult OnGet(int id = 0)
        {
            if (id > 0)
            {
                Contact = _context.Contact.Find(id);
            }
            else
            {
                return Redirect("");
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

                    message.Body = "<img src='http://sandra.wowoco.org/images/thumbnail.jpg' />"
                        + Contact.Name
                        + " has a greeting for you! Visit http://sandra.wowoco.org/read/"
                        + Contact.ID;
                      

                    using (var client = new SmtpClient())
                    {
                        client.EnableSsl = false;
                        client.Host = "smtp18.wowoco.org";
                        client.Port = 2525;
                        client.UseDefaultCredentials = false;
                        client.Send(message);
                    }

                    return RedirectToPage("Confirm");

                } catch (Exception ex){

                    Message = "There was an error sending your message :(";
                }

            }

            return Page();
        }
    }
}
