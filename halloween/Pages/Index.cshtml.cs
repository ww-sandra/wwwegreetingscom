using Microsoft.AspNetCore.Mvc.RazorPages;

namespace halloween.Pages
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "";

        }
    }
}
