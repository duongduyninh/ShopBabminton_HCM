using Microsoft.AspNetCore.Identity;
using ShopBabminton_HCM.DTOs.AuthenticationDTO;

namespace ShopBabminton_HCM.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        public Task<IdentityResult> SignUpAsync(SignUpDTO model);
        public Task<string> SignInAsync(SignInDTO model);
        public Task<string> SignOutAsync();
    }
}
