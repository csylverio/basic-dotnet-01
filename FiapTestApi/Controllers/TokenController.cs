using FiapTestApi.Authentication;
using FiapTestApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FiapTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService tokenService;

        public TokenController(ITokenService tokenService) {
            this.tokenService = tokenService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] Usuario usuario) {
            var token = tokenService.GetToken(usuario);

            if(!string.IsNullOrEmpty(token)) {
                return Ok(token);
            }

            return Unauthorized();
        }
    }
}
