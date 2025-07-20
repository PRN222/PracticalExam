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
    public class PantherAccountRepo : GenericRepository<PantherAccount>
    {
        public PantherAccountRepo(SU25PantherDBContext context) : base(context) { }

        public async Task<PantherAccount?> GetUserAccountAsync(string email, string password)
            => await _context.PantherAccounts.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
    }
}
