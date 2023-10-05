using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace dotnet_ecommerce.Models
{
    public class UserStore : IdentityUser
    {
        public string username {get; set;}
        public string email {get; set;}
    }
}