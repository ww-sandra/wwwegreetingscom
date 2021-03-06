﻿using halloween.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace halloween.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        private BridgeDbContext _context;
        private IConfiguration _configuration { get; set; }

        public IndexModel(BridgeDbContext context, IConfiguration configuration)
        {
            _configuration = configuration;
            _context = context;

        }

        [BindProperty]
        public Contact Contact { get; set; }


        public void OnGet(int id = 0)
        {
            if (id > 0)
            {
                Contact = _context.Contact.Find(id);
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (await isValid())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        if (Contact.ID <= 0)
                        {
                            //ADD TO DB
                            _context.Contact.Add(Contact);
                        }
                        else
                        {
                            //ADD TO DB
                            _context.Contact.Update(Contact);
                        }

                        _context.SaveChanges();

                        return RedirectToPage("Preview", new { id = Contact.ID });

                    }
                    catch { }

                }

            }
            else
            {
                ModelState.AddModelError("Contact.Recaptcha", "Really?!  You're not a robot?  Really??");
            }

            Message = "Error sending your message :(";

            return Page();
        }

        // RE-CAPTCHA VALIDATION
        private async Task<bool> isValid()
        {
            var response = this.HttpContext.Request.Form["g-recaptcha-response"];
            if (string.IsNullOrEmpty(response))
                return false;

            try
            {
                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>();
                    values.Add("secret", _configuration["ReCaptcha:PrivateKey"]);
                    values.Add("response", response);

                    var query = new FormUrlEncodedContent(values);


                    var post = client.PostAsync("https://www.google.com/recaptcha/api/siteverify", query);

                    var json = await post.Result.Content.ReadAsStringAsync();

                    if (json == null)
                        return false;

                    var results = JsonConvert.DeserializeObject<dynamic>(json);

                    return results.success;
                }

            }
            catch (Exception ex)
            {
            }


            return false;
        }
    }
}
