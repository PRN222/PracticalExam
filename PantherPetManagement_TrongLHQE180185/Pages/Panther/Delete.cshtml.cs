using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PantherPetManagement_TrongLHQE180185.Repositories;
using PantherPetManagement_TrongLHQE180185.Repositories.Models;
using PantherPetManagement_TrongLHQE180185.Services;

namespace PantherPetManagement_TrongLHQE180185.Pages.Panther
{
    [Authorize(Roles = "2")]
    public class DeleteModel : PageModel
    {
        private readonly IPantherProfileService _pantherProfileService;

        public DeleteModel(IPantherProfileService pantherProfileService)
        {
            _pantherProfileService = pantherProfileService;
        }

        [BindProperty]
        public PantherProfile PantherProfile { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pantherprofile = await _pantherProfileService.GetByIdAsync(id.Value);

            if (pantherprofile == null)
            {
                return NotFound();
            }
            else
            {
                PantherProfile = pantherprofile;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pantherprofile = await _pantherProfileService.GetByIdAsync(id.Value);
            if (pantherprofile != null)
            {
                PantherProfile = pantherprofile;
                await _pantherProfileService.RemoveAsync(pantherprofile.PantherProfileId);
            }

            return RedirectToPage("./Index");
        }
    }
}
