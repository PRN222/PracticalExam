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
    [Authorize(Roles = "2,3")]
    public class IndexModel : PageModel
    {
        private readonly IPantherProfileService _pantherProfileService;
        public IndexModel(IPantherProfileService pantherProfileService)
        {
            _pantherProfileService = pantherProfileService;
        }

        public IList<PantherProfile> PantherProfile { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public double? Weight { get; set; }
        [BindProperty(SupportsGet = true)]
        public string PantherTypeName { get; set; } = string.Empty;

        // Pagination
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; } = 1;
        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 3;
        public int TotalPages { get; set; } = 0;

        public async Task OnGetAsync()
        {
            // Get all profiles first
            var searchItem = await _pantherProfileService.SearchWithPagingAsync(Weight, PantherTypeName, PageNumber, PageSize);
            PantherProfile = searchItem.items;
            if (searchItem.totalPages > 0)
            {
                TotalPages = searchItem.totalPages;
            }
            else
            {
                TotalPages = 1;
            }
        }
    }
}
