using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store_stock_tracker.Data;

namespace store_stock_tracker.src.WebAPI
{
    [ApiController]
    [Route("api/Point of Service")]
    public class ManagerAPIController : ControllerBase
    {
        [HttpGet("{id}/history")]
        public async Task<IActionResult> GetHistory(
        int id,
        [FromServices] InventoryDbContext context)
        {
            var history = await context.ProductHistories
                .Where(h => h.ProductId == id)
                .OrderByDescending(h => h.Timestamp)
                .ToListAsync();

            return Ok(history);
        }
    }
}
