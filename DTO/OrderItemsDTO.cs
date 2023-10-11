using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ecommerce.DTO
{
    public class OrderItemsDTO
    {
        public int quantity {get; set;}
        public float unit_price {get; set;}
        public int order_id {get; set;}
        public int product_id {get; set;}
    }
}