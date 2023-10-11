using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ecommerce.Data;
using dotnet_ecommerce.DTO;
using dotnet_ecommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace dotnet_ecommerce.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _db;
        
        public OrderController(DataContext db)
        {
            _db = db;
        }

        [HttpGet("GetOrders")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<ActionResult<List<Order>>> GetOrders() 
        {
            return Ok(await _db.Orders.ToListAsync());
        }

        [HttpPost("CreateOrder")]
        public async Task<ActionResult<List<Order>>> CreateOrder(OrderDTO order)
        {
            var newOrder = new Order()
            {
                status = order.status,
                user_id = order.user_id,
                total_value = order.total_value,
                OrderList = new List<OrderItems>()
            };
            _db.Orders.Add(newOrder);
            await _db.SaveChangesAsync();

            return Ok(newOrder);
        }
    }
}