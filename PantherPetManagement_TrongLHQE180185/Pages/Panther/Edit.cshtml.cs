using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PantherPetManagement_TrongLHQE180185.Repositories;
using PantherPetManagement_TrongLHQE180185.Repositories.Models;
using PantherPetManagement_TrongLHQE180185.Services;

namespace PantherPetManagement_TrongLHQE180185.Pages.Panther
{
    [Authorize(Roles = "2")]
    public class EditModel : PageModel
    {
        private readonly IPantherProfileService _pantherProfileService;
        private readonly IPantherTypeService _pantherTypeService;

        public EditModel(IPantherProfileService pantherProfileService, IPantherTypeService pantherTypeService)
        {
            _pantherProfileService = pantherProfileService;
            _pantherTypeService = pantherTypeService;
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
            PantherProfile = pantherprofile;
            ViewData["PantherTypeId"] = new SelectList(await _pantherTypeService.GetAllAsync(), "PantherTypeId", "PantherTypeName");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("PantherProfile.PantherType");
            if (!ModelState.IsValid)
            {
                ViewData["PantherTypeId"] = new SelectList(await _pantherTypeService.GetAllAsync(), "PantherTypeId", "PantherTypeName");
                return Page();
            }

            await _pantherProfileService.UpdateAsync(PantherProfile);

            return RedirectToPage("./Index");
        }
    }
}
