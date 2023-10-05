using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace dotnet_ecommerce.Models
{
    public class UserRole : IdentityRole
    {
        public string role {get; set;}
    }
}