using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ecommerce.Data;
using dotnet_ecommerce.DTO;
using dotnet_ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_ecommerce.Controllers
{
    [ApiController]
    [Route("/account/")]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _db;
        private readonly SignInManager<UserStore> _signinManager;
        private readonly UserManager<UserStore> _userManager;
        public LoginController(DataContext db, SignInManager<UserStore> signInManager, UserManager<UserStore> userManager){
            _db = db;
            _signinManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<List<User>>> CreateUser(UserDTO req)
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
                    Console.WriteLine("Adding Password");
                    await _userManager.AddToRoleAsync(newUser, "User");
                    return Ok(newUser);
                } else {
                    foreach(var test in added.Errors){
                        Console.WriteLine(test.Code);
                        Console.WriteLine(test.Description);
                    }
                    return BadRequest(newUser);
                }

            } else {
                return BadRequest("User already exists");
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> LoginAccount(UserDTO req)
        {
            var result = await _signinManager.PasswordSignInAsync(req.username, req.password, true, false);
            if (result.Succeeded){
                Console.WriteLine("Signed in yeeee");
            }
            if (result.IsLockedOut){
                Console.WriteLine("Locked out :(");
            }
            return Ok(result);
        }

        
    }
}