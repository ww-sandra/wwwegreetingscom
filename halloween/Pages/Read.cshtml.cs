using halloween.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;

namespace halloween.Pages
{
    public class ReadModel : PageModel
    {
        public string Message { get; set; }

        public Contact Contact { get; set; }

        private BridgeDbContext _context;
        private IConfiguration _configuration;

        public ReadModel(BridgeDbContext context, IConfiguration configuration)
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

            if (Contact == null)
                return RedirectToPage("Index");


            return Page();


        }

       
    }
}
