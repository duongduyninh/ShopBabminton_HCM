using Microsoft.AspNetCore.Identity;
using ShopBabminton_HCM.DTOs.AuthenticationDTO;
using ShopBabminton_HCM.Interfaces;

namespace ShopBabminton_HCM.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }
        public async Task<string> SignInAsync(SignInDTO signIn)
        {
            var User = await _authenticationRepository.SignInAsync(signIn);

            return User;
        }


        public async Task<IdentityResult> SignUpAsync(SignUpDTO signUp)
        {
            var user = await _authenticationRepository.CreateUserAsync(signUp);
            return user;
        }

        public Task<string> SignOutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
