using PantherPetManagement_TrongLHQE180185.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement_TrongLHQE180185.Services
{
    public interface IPantherAccountService
    {
        Task<PantherAccount?> GetUserAccountAsync(string userName, string password);
    }
}
