using halloween.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace halloween.Pages
{
    public class ConfirmModel : PageModel
    {
        public string Message { get; set; }

       

        public void OnGet()
        {
            Message = "Success, your scary greeting is on its way!";
            
        }

      
    }
}
