using PantherPetManagement_TrongLHQE180185.Repositories.Basic;
using PantherPetManagement_TrongLHQE180185.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PantherPetManagement_TrongLHQE180185.Repositories.Repos
{
    public class PantherTypeRepo : GenericRepository<PantherType>
    {
        public PantherTypeRepo(SU25PantherDBContext context) : base(context) { }
    }
}
