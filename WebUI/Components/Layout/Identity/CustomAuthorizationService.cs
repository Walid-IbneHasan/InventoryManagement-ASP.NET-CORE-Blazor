using System.Security.Claims;

namespace WebUI.Components.Layout.Identity
{
    public class CustomAuthorizationService : ICustomAuthorizationService
    {
        public bool CustomClaimChecker(ClaimsPrincipal user, string specificClaim)
        {
            if(!user.Identity!.IsAuthenticated) return false;
            var getClaim = user.HasClaim(_ => _.Type == specificClaim);
            if(!getClaim) return false;

            var getState = user.Claims.FirstOrDefault(_ => _.Type == specificClaim)!.Value;
            return Convert.ToBoolean(getState) is true;
        }
    }
}
