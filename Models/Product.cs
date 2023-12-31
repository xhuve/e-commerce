using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace dotnet_ecommerce.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id {get; set;}
        public string name {get; set;}        
        public float price  {get; set;}
        public string category {get; set;}
        [JsonProperty("OrderList")]
        public OrderItems? OrderList {get; set;}
    }
}