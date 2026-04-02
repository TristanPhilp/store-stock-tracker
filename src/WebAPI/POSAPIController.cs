using Microsoft.AspNetCore.Mvc;
using store_stock_tracker.src.Tools;
using store_stock_tracker.src.WebAPI.Utils;
using System.Reflection.Metadata.Ecma335;
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
        if (amount >= 0)
        {
            return Problem("Amount cannot be positive");
        }
        switch (InventoryWorker.UpdateStock(id, amount))
        {
            case 0:
                return Ok();
            case 1:
                return Problem("Update failed. Update statement not valid.");
            case 2:
                return Problem("No matches or mulitple matches for given ID. Aborting.");
            default:
                return Problem("Update failed for unknown reason.");
        }
    }
}
