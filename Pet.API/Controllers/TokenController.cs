using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Pet.API.Models;
using Pet.Domain.Account;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pet.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TokenController : ControllerBase
	{
		private readonly IAuthenticate _authenticate;
		private readonly IConfiguration _configuration;

		public TokenController(IAuthenticate authenticate, IConfiguration configuration)
		{
			_authenticate = authenticate;
			_configuration = configuration;
		}

		[HttpPost("RegistrarUser")]
		[ApiExplorerSettings(IgnoreApi = true)]
		[Authorize]
		public async Task<ActionResult> RegistrarUser(LoginModel userInfo)
		{
			var result = await _authenticate.RegisterUser(userInfo.Email, userInfo.Password);
			if (result)
			{
				return Ok("Usuário Registrado");
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Login invalido.");
				return BadRequest(ModelState);
			}
		}

		[HttpPost("LoginUser")]
		[AllowAnonymous]
		public async Task<ActionResult<UserToken>> Login(LoginModel userInfo)
		{
			var result = await _authenticate.Authenticate(userInfo.Email, userInfo.Password);
			if (result)
			{
				//return Ok();
				return GenerateToken(userInfo);
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Login invalido.");
				return BadRequest(ModelState);
			}
		}

		private UserToken GenerateToken(LoginModel userInfo)
		{
			var claims = new[]
			{
				new Claim("email", userInfo.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			};

			var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));

			var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

			var expiration = DateTime.UtcNow.AddMinutes(60);

			JwtSecurityToken token = new JwtSecurityToken(
				issuer: _configuration["Jwt:Issuer"],
				audience: _configuration["Jwt:Audience"],
				claims: claims,
				expires: expiration,
				signingCredentials: credentials
				);

			return new UserToken()
			{
				Token = new JwtSecurityTokenHandler().WriteToken(token),
				Expiration = expiration
			};
		}
	}
}
