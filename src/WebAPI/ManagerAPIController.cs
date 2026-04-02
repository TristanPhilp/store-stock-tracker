using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store_stock_tracker.Data;
using store_stock_tracker.Models;
using store_stock_tracker.src.WebAPI.Utils;
using System.Text;

namespace store_stock_tracker.src.WebAPI
{
    [ApiController]
    [Route("api/Manager")]
    public class ManagerAPIController : ControllerBase
    {
        [HttpGet("history")]
        public IActionResult HistoryById([FromQuery] int id)
        {
            var history = InventoryWorker.GetHistoryById(id);

            return Ok(history);
        }
        [HttpGet("Display Items Needing Stock")]
        public IActionResult ReStockSearch()
        {
            List<Product> results = InventoryWorker.RestockSearch();

            if (results.Count == 0)
            {
                return NotFound("No products found.");
            }
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Name                           |Quantity |   Price | Restock Threshold");
            foreach (Product result in results)
            {
                builder.AppendLine($"{result.Name,-30} |{result.Quantity,8} | {result.Price,7} | {result.Restock_Threshold}");
            }
            return Ok(builder.ToString());
        }
        [HttpPost("Process Restock")]
        public IActionResult ReStock([FromQuery] int id, int amount)
        {
            var restock = InventoryWorker.ReStock(id, amount);

            return Ok();
        }
        [HttpPost("Update Prices")]
        public IActionResult UpdatePrice([FromQuery] int id, int amount)
        {
            var restock = InventoryWorker.UpdatePrice(id, amount);

            return Ok();
        }
        [HttpPost("Update Restock Threshold")]
        public IActionResult UpdateReStock([FromQuery] int id, int amount)
        {
            var restock = InventoryWorker.SetReStock(id, amount);

            return Ok();
        }
    }
}
