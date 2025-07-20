using PantherPetManagement_TrongLHQE180185.Repositories;
using PantherPetManagement_TrongLHQE180185.Repositories.Models;
using PantherPetManagement_TrongLHQE180185.Repositories.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement_TrongLHQE180185.Services
{
    public class PantherAccountService : IPantherAccountService
    {
        private readonly PantherAccountRepo _pantheraccountRepo;

        public PantherAccountService(PantherAccountRepo pantherAccountRepo)
        {
            _pantheraccountRepo = pantherAccountRepo;
        }

        public async Task<PantherAccount?> GetUserAccountAsync(string email, string password)
        {
            return await _pantheraccountRepo.GetUserAccountAsync(email, password);
        }
    }
}
