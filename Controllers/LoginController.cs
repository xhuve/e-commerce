using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using dotnet_ecommerce.Data;
using dotnet_ecommerce.DTO;
using dotnet_ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Cms;

namespace dotnet_ecommerce.Controllers
{
    [ApiController]
    [Route("/account/")]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly DataContext _db;
        
        private readonly SignInManager<UserStore> _signinManager;
        private readonly UserManager<UserStore> _userManager;
        public LoginController(DataContext db, SignInManager<UserStore> signInManager, UserManager<UserStore> userManager, IConfiguration configuration){
            _db = db;
            _signinManager = signInManager;
            _userManager = userManager;
            _config = configuration;
        }


        [HttpPost("CreateUser")]
        public async Task<ActionResult> CreateUser(UserDTO req)
        {
            if(await _userManager.FindByNameAsync(req.username) == null)
                {
                    var newUser = new UserStore()
                    {
                        UserName = req.username,
                        User = req.first_name,
                        Email = req.email          
                    }; 
                    var added = await _userManager.CreateAsync(newUser, req.password);
                    if (added.Succeeded){
                        await _userManager.AddToRoleAsync(newUser, "User");
                        return Ok(newUser);
                    } else {
                    foreach(var test in added.Errors){
                        Console.Write(test.Code + " ");
                        Console.WriteLine(test.Description);
                    }
                    return BadRequest(newUser);
                }
            } else {
                return BadRequest("User already exists");
            }
        }

        [HttpGet("Logged")]
        public IActionResult isLogged()
        {
            if (User.Identity.IsAuthenticated) {
                return Ok(User.Identity.Name);
            } else {
                return BadRequest(false);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult> LoginAccount(UserDTO req)
        {
            var result = await _signinManager.PasswordSignInAsync(req.username, req.password, true, false);

            if (result.Succeeded){
                Console.WriteLine("Signed in yeeee");
                
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]);


                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, req.first_name),
                        new Claim(ClaimTypes.Role, "User")
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                
                Console.WriteLine(tokenDescriptor.Expires.ToString());

                var token = tokenHandler.CreateToken(tokenDescriptor);
                Console.WriteLine(token);
            } else {
                Console.WriteLine("Not signed in for whatever reason.");
                return BadRequest("Not signed in for whatever reason.");
            }
            if (result.IsLockedOut){
                Console.WriteLine("Locked out :(");
            }
            return Ok(result);
        }
    }
}