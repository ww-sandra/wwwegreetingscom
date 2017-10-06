using halloween.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
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

        public PageResult OnPost()
        {
            var val = this.Contact.Name;
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
