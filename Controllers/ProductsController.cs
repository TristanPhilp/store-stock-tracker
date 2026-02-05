using Microsoft.AspNetCore.Mvc;
using store_stock_tracker.Data;
using store_stock_tracker.Models;

namespace store_stock_tracker.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    [HttpPost("test-product")]
    public async Task<IActionResult> TestInsert(
        [FromServices] InventoryDbContext context)
    {
        context.Products.Add(new Product
        {
            Name = "Test Item",
            Sku = "TEST-001",
            Quantity = 10,
            Price = 9.99m
        });

        await context.SaveChangesAsync();
        return Ok("Inserted");
    }
}