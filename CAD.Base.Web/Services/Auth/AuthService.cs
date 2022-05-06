using CAD.Base.Common.ViewModels.Account;
using CAD.Base.Web.Interfaces.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CAD.Base.Web.Services.Auth
{
    public class AuthService : IAuthService
    {
        private IConfiguration configuration;
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        
        public const string SecretKeyName = "SecretKey";

        public AuthService(IConfiguration configuration, 
            UserManager<IdentityUser> userManager, 
            SignInManager<IdentityUser> signInManager)
        {
            this.configuration = configuration;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<LoginResponse> Token(LoginUser userLogin)
        {
            var user = await userManager.FindByEmailAsync(userLogin.Email);
            if (user != null) {
                var result = await signInManager.CheckPasswordSignInAsync(user, userLogin.Password, false);

                if (result.Succeeded) return CreateToken(user);
            }

            return null;
        }

        public Task<LoginResponse> RefreshToken(string refreshToken)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> Register(RegisterUser userRegister)
        {
            var user = new IdentityUser() 
                {UserName = userRegister.Email,  Email = userRegister.Email, EmailConfirmed = true};
            
            var identityResult = await  userManager.CreateAsync(user, userRegister.Password);

            if (identityResult.Succeeded) { return true; }
            
            return false;
        }

        private LoginResponse CreateToken(IdentityUser user)
        {
            var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>(SecretKeyName));

            ClaimsIdentity claims = new ClaimsIdentity();
            claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                // Nuestro token va a durar un día
                Expires = DateTime.UtcNow.AddDays(1),
                // Credenciales para generar el token usando nuestro secretykey y el algoritmo hash 256
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                                                            SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var createdToken = tokenHandler.CreateToken(tokenDescriptor);

            var token = tokenHandler.WriteToken(createdToken);

            LoginResponse response = new LoginResponse() { Token = token };

            return response;
        }
    }
}
