using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PantherPetManagement_TrongLHQE180185.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await HttpContext.SignOutAsync("Cookies");
            return Redirect("/Login");
        }
    }
}
