using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OnlineCasino.Application.DTOs;
using OnlineCasino.Application.Services.Interfaces;
using OnlineCasino.Shared.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace OnlineCasinoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;
        private IConfiguration _configuration;
        private IAuthService _authService;

        public AuthController(ILogger<AuthController> logger, IConfiguration configuration, IAuthService authService)
        {
            _logger = logger;
            _configuration = configuration;
            _authService = authService;
        }   

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody]LoginRequestDTO loginRequest)
        {
            //Check if login is successful
            Validations status = _authService.AttemptLogin(loginRequest);

            if(status == Validations.FOUND)
            {
                //Generate Secure Key Token
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var Sectoken = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                  _configuration["Jwt:Issuer"],
                  null,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                var token = new JwtSecurityTokenHandler().WriteToken(Sectoken);

                return Ok(token);
            }
            else if(status == Validations.UNKNOWN_USERNAME)
            {
                return BadRequest("Username provided does not exist");
            }else if(status == Validations.INCORRECT_PASSWORD)
            {
                return BadRequest("Password provided is incorrect");
            }else
            {
                return BadRequest("An error in the system has been encountered");
            }
        }
    }
}
