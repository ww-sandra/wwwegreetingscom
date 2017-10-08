using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace halloween.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        [BindProperty]
        public string name { get; set; }

        [BindProperty]
        public string email { get; set; }

        [BindProperty]
        public string subject { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Hey dummy, that was rude!")]
        public string message { get; set; }

        public void OnGet()
        {
           
        }

        public void OnPost()
        {
            if (string.IsNullOrEmpty(message))
            {
                //blah bla
            }
            
        }

    }
}
