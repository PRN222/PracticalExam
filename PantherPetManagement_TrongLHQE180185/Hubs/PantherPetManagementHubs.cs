using Microsoft.AspNetCore.SignalR;
using PantherPetManagement_TrongLHQE180185.Services;

namespace PantherPetManagement_TrongLHQE180185.Hubs
{
    public class PantherPetManagementHubs : Hub
    {
        private readonly IPantherProfileService _pantherprofileService;

        public PantherPetManagementHubs(IPantherProfileService pantherprofileService)
        {
            _pantherprofileService = pantherprofileService;
        }

        public async Task HubDelete_PantherProfile(string id)
        {
            await Clients.All.SendAsync("Receive_DeletePantherProfile", id);

            await _pantherprofileService.RemoveAsync(int.Parse(id));
        }
    }
}
