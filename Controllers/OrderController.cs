using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ecommerce.Data;
using dotnet_ecommerce.DTO;
using dotnet_ecommerce.Models;


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

        public class OrderCreateRequest
        {
            public OrderDTO Order { get; set; }
            public User User { get; set; }
        }
        [HttpPost]
        public async Task<ActionResult<List<Order>>> CreateOrder(OrderCreateRequest req)
        {
            var newOrder = new Order()
            {
                status = req.Order.status,
                user_id = req.User.id,
                total_value = req.Order.total_value,
                User = req.User,
                OrderList = new List<OrderItems>()
            };
            _db.Orders.Add(newOrder);
            await _db.SaveChangesAsync();

            return Ok(newOrder);
        }

    }
}