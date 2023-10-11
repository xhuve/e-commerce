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
    [Route("/account/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _db;
        private readonly SignInManager<User> _signinManager;
        public LoginController(DataContext db, SignInManager<User> signInManager){
            _db = db;
            _signinManager = signInManager;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> LoginAccount(UserDTO req)
        {
            var result = await _signinManager.PasswordSignInAsync(req.username, req.password, true, false);
            if (result.Succeeded){
                Console.WriteLine("Signed in yeeee");
            }
            if (result.IsLockedOut){
                Console.WriteLine("Locked out :()");
            }
            return Ok();
        }

        
    }
}