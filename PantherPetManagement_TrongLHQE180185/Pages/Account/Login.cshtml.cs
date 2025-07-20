using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using PantherPetManagement_TrongLHQE180185.Services;

namespace PantherPetManagement_TrongLHQE180185.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IPantherAccountService _accountService;

        public LoginModel(IPantherAccountService accountService)
        {
            _accountService = accountService;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public string? ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Email is required")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "Password is required")]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;

            [Display(Name = "Remember me")]
            public bool RememberMe { get; set; }
        }

        public async Task OnGetAsync(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;

            if (ModelState.IsValid)
            {
                var user = await _accountService.GetUserAccountAsync(Input.Email, Input.Password);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.Email ?? string.Empty),
                        new Claim("UserId", user.AccountId.ToString()),
                        new Claim(ClaimTypes.Role, user.RoleId.ToString())
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                    await HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(claimsIdentity));

                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return Redirect("/Panther/Index");
                    }
                }

                ModelState.AddModelError(string.Empty, "Invalid Email or Password!.");
            }

            return Page();
        }
    }
}
