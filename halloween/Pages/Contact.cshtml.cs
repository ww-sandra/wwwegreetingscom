using halloween.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;

namespace halloween.Pages
{
    public class ContactModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty]
        public Contact Contact { get; set; }


        public void OnGet()
        {
            Message = "";
        }

        public async Task<IActionResult> OnPost()
        {
            if (await isValid())
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        //SEND MESSAGE
                        MailMessage message = new MailMessage();
                        message.Subject = "[Wonder Women Coders] " + Contact.Subject;
                        message.To.Add(new MailAddress(Contact.Email, Contact.Name));
                        message.From = new MailAddress("sender170802@mail02.wonderwomencoders.com", "Wonder Women Coders");
                        message.IsBodyHtml = true;

                        message.Body = Contact.Message;
                        using (var client = new SmtpClient())
                        {
                            client.Host = "mail02.wonderwomencoders.com";
                            client.Port = 25;
                            var credentials = new NetworkCredential("sender170802@mail02.wonderwomencoders.com", "Got2code!");
                            client.UseDefaultCredentials = false;
                            client.Credentials = credentials;
                            client.Send(message);

                        }

                        return RedirectToPage("Preview");

                    }
                    catch { }

                }

            } else
            {
                 ModelState.AddModelError("Recaptcha", "Really?!  You're not a robot?  Really??");
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
                    values.Add("secret", "6Ld-fREUAAAAAKZBYEo0n60jMHb5i6NE-hkBn5BF");
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
