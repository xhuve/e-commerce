using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_ecommerce.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int order_id { get; set; }
        public int user_id {get; set;}
        public string status {get; set;}
        public float total_value {get; set;}
        public User User {get;set;}
        public ICollection<OrderItems> OrderList {get; set;} 
    }
}