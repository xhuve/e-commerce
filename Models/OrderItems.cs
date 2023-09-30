using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ecommerce.Models
{
    public class OrderItems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {get; set;}
        public int order_id {get; set;}
        public int product_id {get; set;}
        public int quantity {get; set;}
        public float unit_price {get; set;}
        public Order Order {get; set;}
        public ICollection<Product> Products {get; set;}
    }
}