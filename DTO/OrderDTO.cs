using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ecommerce.Models;

namespace dotnet_ecommerce.DTO
{
    public class OrderDTO
    {
        public string status {get; set;}
        public float total_value {get; set;}
        public User user {get;set;}
    }
}