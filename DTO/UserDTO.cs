using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ecommerce.DTO
{
    public class UserDTO
    {
        public string username { get; set; }
        public string password { get; set; }
        public string? first_name { get; set; }
        public string email {get;set;}
    }
}