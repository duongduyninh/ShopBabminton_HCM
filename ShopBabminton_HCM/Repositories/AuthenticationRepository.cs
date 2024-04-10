

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ShopBabminton_HCM.Data;
using ShopBabminton_HCM.DTOs.AuthenticationDTO;
using ShopBabminton_HCM.Helpers;
using ShopBabminton_HCM.Interfaces;
using ShopBabminton_HCM.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopBabminton_HCM.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly ICartRepository _cartRepository;
        private readonly DbContextStoreBabmintion _context;

        public AuthenticationRepository(UserManager<AppUser> userManager
                                        , IConfiguration configuration
                                        , RoleManager<IdentityRole> roleManager
                                        , ICartRepository cartRepository
                                        , DbContextStoreBabmintion context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _cartRepository = cartRepository;
            _context = context;
        }

        public Task<bool> CreateCartAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> CreateUserAsync(SignUpDTO model)
        {
            var checkUser = await _userManager.FindByEmailAsync(model.Email);
            if (checkUser != null)
            {
                return IdentityResult.Failed(new IdentityError { Description = "Email đã tồn tại." }); //co the kem theo huong dan 
            }
            var user = new AppUser
            {
                UserName = model.Username,
                Email = model.Email,
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded) 
            {
                if (!await _roleManager.RoleExistsAsync(AppRole.Customer))
                {
                    await _roleManager.CreateAsync(new IdentityRole(AppRole.Customer));
                }

                await _userManager.AddToRoleAsync(user, AppRole.Customer);
                _context.SaveChanges();
                await _cartRepository.CreateCartAsync(user.Id);
            }
            return result;
        }

        public async Task<string> SignInAsync(SignInDTO model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            var passswordValid = await _userManager.CheckPasswordAsync(user, model.Password);

            if (user != null || passswordValid)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, model.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                var userRole = await _userManager.GetRolesAsync(user);
                foreach ( var role in userRole)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
                }

                var issuer = _configuration["JWT:ValidIssuer"];
                var audience = _configuration["JWT:ValidAudience"];
                var expires = DateTime.Now.AddMinutes(10);
                var authenkey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    expires: expires,
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authenkey, SecurityAlgorithms.HmacSha256)
                    );

                var createToken = new JwtSecurityTokenHandler().WriteToken(token);

                return createToken;
            }
            else
            {
                return ("Sai Tài Khoản Hoặc mật khẩu");
            }

        }

        public async Task<bool> CheckUserIdValidAsync(string userId)
        {
            var result = await _userManager.FindByIdAsync(userId);  
            if (result == null) { return false; }else { return true;}
        }

        public Task<string> SignOutAsync()
        {
            throw new NotImplementedException();
        }
    }
}
