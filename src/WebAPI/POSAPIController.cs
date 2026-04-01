using Microsoft.AspNetCore.Mvc;
using store_stock_tracker.src.Tools;
using store_stock_tracker.src.WebAPI.Utils;
using System.Text;

[ApiController]
[Route("api/Point of Service")]
public class POSAPIController : ControllerBase
    {
    [HttpGet("SKU Search")]
    public IActionResult SKUSearch([FromQuery] string input)
    {
        Product result = InventoryWorker.SearchBySKU(input);
        return Ok(result);
    }

    [HttpPost("Decrease Stock")]
    public IActionResult SKUDecreaseStock([FromQuery] int id, int amount)
    {
        return Ok();
    }
}
