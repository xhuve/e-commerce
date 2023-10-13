using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ecommerce.Data;
using dotnet_ecommerce.DTO;
using dotnet_ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ecommerce.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _db;

        public UserController(DataContext db){
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return Ok(await _db.Users.ToListAsync());
        }

        

        [HttpDelete]
        public async Task<ActionResult<User>> DeleteUser(User User)
        {
            var DelUser = _db.Users.Where(x => User.id == x.id);
            _db.Users.Remove((User)DelUser);
            await _db.SaveChangesAsync();
            return Ok(DelUser);
        }
    }
}