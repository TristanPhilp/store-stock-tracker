using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using store_stock_tracker.Data;
using store_stock_tracker.src.WebAPI.Utils;

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
        [HttpGet("Process Restock")]
        public IActionResult ReStock([FromQuery] int id)
        {
            var history = InventoryWorker.GetHistoryById(id);

            return Ok(history);
        }
        [HttpGet("Display Items Needing Stock")]
        public IActionResult ReStockSearch([FromQuery] int id)
        {
            var history = InventoryWorker.GetHistoryById(id);

            return Ok(history);
        }
    }
}
