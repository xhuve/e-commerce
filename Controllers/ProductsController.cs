using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ecommerce.Data;
using dotnet_ecommerce.DTO;
using dotnet_ecommerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_ecommerce.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly DataContext _db;


        public ProductsController(DataContext db){
            _db = db;
        }

        [HttpGet]
        [Authorize(Policy = "UserOnly")]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            return Ok(await _db.Products.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(ProductDTO req)
        {
            var newProduct = new Product()
            {
                name = req.name,
                price = req.price,
                category = req.category,
            };
            _db.Products.Add(newProduct);
            await _db.SaveChangesAsync();

            return Ok(newProduct);
        }

        [HttpDelete]
        public async Task<ActionResult<Product>> DeleteProduct(Product Product)
        {
            var DelProduct = _db.Products.Where(x => Product.id == x.id);
            _db.Products.Remove((Product)DelProduct);
            await _db.SaveChangesAsync();
            return Ok(DelProduct);
        }
    }
}