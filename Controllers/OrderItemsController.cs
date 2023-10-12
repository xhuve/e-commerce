using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ecommerce.Data;
using dotnet_ecommerce.DTO;
using dotnet_ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_ecommerce.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class OrderItemsController : ControllerBase
    {
        private readonly DataContext _db;
        
        public OrderItemsController(DataContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderItems>>> GetOrderList() 
        {
            return Ok(await _db.OrderItems.ToListAsync());
        }

        public class CreateOrderReq {
            public OrderItemsDTO OrderItems{get; set;}
            public Product Product {get; set;}
            public Order Order {get; set;}
        }

        [HttpPost]
        public async Task<ActionResult<List<Order>>> CreateOrderItems(CreateOrderReq req)
        {
            var newOrderList = new OrderItems()
            {
                order_id = req.Order.id,
                product_id = req.Product.id,
                quantity = req.OrderItems.quantity,
                unit_price = req.OrderItems.unit_price
            };
            _db.OrderItems.Add(newOrderList);
            await _db.SaveChangesAsync();

            return Ok(newOrderList);
        }

        [HttpDelete]
        public async Task<ActionResult<User>> DeleteOrderitem(OrderItems Orderitems)
        {
            var DelOrder = _db.OrderItems.Where(x => Orderitems.id == x.id);
            _db.OrderItems.Remove((OrderItems)DelOrder);
            await _db.SaveChangesAsync();
            return Ok(DelOrder);
        }
    }
}