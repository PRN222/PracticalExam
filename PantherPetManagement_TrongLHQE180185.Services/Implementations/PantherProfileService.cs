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
    public class PantherProfileService : IPantherProfileService
    {
        private readonly PantherProfileRepo _pantherProfileRepo;

        public PantherProfileService(PantherProfileRepo pantherProfileRepo)
        {
            _pantherProfileRepo = pantherProfileRepo;
        }

        public async Task<List<PantherProfile>> GetAllAsync()
        {
            return await _pantherProfileRepo.GetAllAsync();
        }

        public async Task<PantherProfile> GetByIdAsync(int code)
        {
            return await _pantherProfileRepo.GetByIdAsync(code);
        }

        public async Task<List<PantherProfile>> SearchAsync(double? weight, string typeName)
        {
            return await _pantherProfileRepo.SearchAsync(weight, typeName);
        }

        public async Task<(List<PantherProfile> items, int totalPages)> SearchWithPagingAsync(double? weight, string typeName, int page = 1, int pageSize = 3)
        {
            return await _pantherProfileRepo.SearchWithPagingAsync(weight, typeName, page, pageSize);
        }

        public async Task<int> CreateAsync(PantherProfile profile)
        {
            return await _pantherProfileRepo.CreateAsync(profile);
        }

        public async Task<int> UpdateAsync(PantherProfile profile)
        {
            return await _pantherProfileRepo.UpdateAsync(profile);
        }

        public async Task<bool> RemoveAsync(int code)
        {
            var profile = await _pantherProfileRepo.GetByIdAsync(code);
            if (profile != null)
            {
                return await _pantherProfileRepo.RemoveAsync(profile);
            }
            return false;
        }
    }
}
