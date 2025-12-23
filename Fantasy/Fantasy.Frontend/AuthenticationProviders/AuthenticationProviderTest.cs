using Fantasy.Shared.Enums;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Fantasy.Frontend.AuthenticationProviders
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            await Task.Delay(3000);
            var anonimous = new ClaimsIdentity();
            var user = new ClaimsIdentity(authenticationType: "test");

            var admin = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName","Marcelo"),
                new Claim("LastName","Fuentes"),
                new Claim(ClaimTypes.Name, "chelo@yopmail.com"),
                new Claim(ClaimTypes.Role, "Admin"),
            }, authenticationType: "test");

            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(user)));
        }
    }
}
