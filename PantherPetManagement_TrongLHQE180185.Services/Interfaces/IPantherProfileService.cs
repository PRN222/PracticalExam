using PantherPetManagement_TrongLHQE180185.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement_TrongLHQE180185.Services
{
    public interface IPantherProfileService
    {
        Task<List<PantherProfile>> GetAllAsync();
        Task<PantherProfile> GetByIdAsync(int code);
        Task<List<PantherProfile>> SearchAsync(double? weight, string typeName);
        Task<(List<PantherProfile> items, int totalPages)> SearchWithPagingAsync(double? weight, string typeName, int page = 1, int pageSize = 3);
        Task<int> CreateAsync(PantherProfile profile);
        Task<int> UpdateAsync(PantherProfile profile);
        Task<bool> RemoveAsync(int code);
    }
}
