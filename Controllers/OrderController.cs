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
    public class OrderController : ControllerBase
    {
        private readonly DataContext _db;
        
        public OrderController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> GetOrders() 
        {
            return Ok(await _db.Orders.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Order>>> CreateUser(OrderDTO req, User user)
        {
            var newOrder = new Order()
            {
                status = req.status,
                total_value = req.total_value,
                user = user,
                OrderList = new List<OrderItems>()
            };
            _db.Orders.Add(newOrder);
            await _db.SaveChangesAsync();

            return Ok(newOrder);
        }

    }
}