using Microsoft.AspNetCore.Identity;
using ShopBabminton_HCM.DTOs.AuthenticationDTO;

namespace ShopBabminton_HCM.Interfaces
{
    public interface IAuthenticationRepository
    {
        public Task<IdentityResult> CreateUserAsync(SignUpDTO model);
        public Task<bool> CreateCartAsync();
        public Task<string> SignInAsync(SignInDTO model);
        public Task<string> SignOutAsync();
        public Task<bool> CheckUserIdValidAsync(string model);
    }
}
