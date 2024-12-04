using Application.DTO.Request.ActivityTracker;
using Application.DTO.Request.Identity;
using Application.DTO.Response;
using Application.DTO.Response.ActivityTracker;
using Application.DTO.Response.Identity;
using Application.Interface.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Identity
{
    public class AccountService(IAccount account) : IAccountService
    {
        public async Task<ServiceResponse> CreateUserAsync(CreateUserRequestDTO model)
        => await account.CreateUserAsync(model);

        public async Task<IEnumerable<GetUserWithClaimResponseDTO>> GetUsersWithClaimsAsync()
        => await account.GetUserWithClaimsAsync();

        public async Task<ServiceResponse> LoginAsync(LoginUserRequestDTO model)
        => await account.LoginAsync(model);

        public async Task SetUpAsync() => await account.SetUpAsync();


        public async Task<ServiceResponse> UpdateUserAsync(ChangeUserClaimRequestDTO model)
        => await account.UpdateUserAsync(model);

        private async Task<IEnumerable<ActivityTrackerResponseDTO>> GetActivitiesAsync()
            => await account.GetActivitiesAsync();

        public Task SaveActivityAsync(ActivityTrackerRequestDTO model)
            => account.SaveActivityAsync(model);
        public async Task<IEnumerable<IGrouping<DateTime, ActivityTrackerResponseDTO>>> GroupActivities()
        {
            var data = (await GetActivitiesAsync()).GroupBy(e => e.Date).AsEnumerable();
            return data;
        }

    }
}
