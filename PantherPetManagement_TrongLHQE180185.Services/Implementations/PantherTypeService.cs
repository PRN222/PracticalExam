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
    public class PantherTypeService : IPantherTypeService
    {
        private readonly PantherTypeRepo _pantherTypeRepo;

        public PantherTypeService(PantherTypeRepo pantherTypeRepo)
        {
            _pantherTypeRepo = pantherTypeRepo;
        }

        public async Task<List<PantherType>> GetAllAsync()
        {
            return await _pantherTypeRepo.GetAllAsync();
        }
    }
}
