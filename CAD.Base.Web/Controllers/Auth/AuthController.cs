using CAD.Base.Common.ViewModels.Account;
using CAD.Base.Web.Interfaces.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CAD.Base.Web.Controllers.Account
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService authServices;
        public AuthController(IAuthService service)
        {
            authServices = service;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<LoginResponse>> Login(LoginUser loginUser)
        {
            var response = await authServices.Token(loginUser);
            if (response is null) { BadRequest(); }

            return response;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult> Register(RegisterUser registerUser)
        {
            var response = await authServices.Register(registerUser);
            if (response == false) { BadRequest(); }

            return Ok();
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<ActionResult<LoginResponse>> RefreshToken(string refhreshToken)
        {
            var response = await authServices.RefreshToken(refhreshToken);
            if (response is null) { BadRequest(); }

            return response;
        }
    }
}
