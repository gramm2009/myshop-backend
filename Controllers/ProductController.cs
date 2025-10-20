using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using MyShop.Data;
using Microsoft.EntityFrameworkCore;

namespace MyShop.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet("getProduct")]
        public async Task<IActionResult> GetProduct()
        {
            try
            {
                var products = await _context.Products
                    .Select(p => new
                    {
                        p.Id,
                        p.ProductName,
                        p.Price,
                        BrandName = p.Brand.BrandName,
                        CategoryName = p.Category.CategoryName
                    })
                    .ToListAsync();

                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка: {ex.Message}");
            }

        }
    }
}
