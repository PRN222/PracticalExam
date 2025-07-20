using PantherPetManagement_TrongLHQE180185.Repositories.Basic;
using PantherPetManagement_TrongLHQE180185.Repositories.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement_TrongLHQE180185.Repositories.Repos
{
    public class PantherProfileRepo : GenericRepository<PantherProfile>
    {
        public PantherProfileRepo(SU25PantherDBContext context) : base(context) { }

        public new async Task<List<PantherProfile>> GetAllAsync()
            => await _context.PantherProfiles.Include(b => b.PantherType).ToListAsync() ?? new List<PantherProfile>();

        public new async Task<PantherProfile> GetByIdAsync(int code)
            => await _context.PantherProfiles
                .Include(b => b.PantherType)
                .FirstOrDefaultAsync(b => b.PantherProfileId == code) ?? new PantherProfile();

        public async Task<List<PantherProfile>> SearchAsync(double? weight, string typeName)
        {
            var query = await _context.PantherProfiles
             .Include(b => b.PantherType)
             .Where(b => (b.PantherType.PantherTypeName.Contains(typeName) || string.IsNullOrEmpty(typeName))
             || (!weight.HasValue || b.Weight == weight.Value)
             ).ToListAsync();
            return query ?? new List<PantherProfile>();
        }

        public async Task<(List<PantherProfile> items, int totalPages)> SearchWithPagingAsync(double? weight, string typeName, int page = 1, int pageSize = 3)
        {
            var query = _context.PantherProfiles.Include(b => b.PantherType)
             .Where(b => (b.PantherType.PantherTypeName.Contains(typeName) || string.IsNullOrEmpty(typeName))
             || (!weight.HasValue || b.Weight == weight.Value)
             ).AsQueryable();

            // paging 
            var totalCount = await query.CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / pageSize);
            var items = await query
                .Include(b => b.PantherType)
                .OrderByDescending(b => b.ModifiedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items ?? new List<PantherProfile>(), totalPages);
        }
    }
}
