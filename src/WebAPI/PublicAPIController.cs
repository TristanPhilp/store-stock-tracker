using Microsoft.AspNetCore.Mvc;
using store_stock_tracker.src.Tools;
using store_stock_tracker.src.WebAPI.Utils;
using System.Text;
using store_stock_tracker.Models;
[ApiController]
[Route("api/products")]
public class PublicAPIController : ControllerBase
{
    [HttpGet("Sku Search")]
    public IActionResult SKUSearch([FromQuery] string input)
    {
        Product result = InventoryWorker.SearchBySKU(input);
        if (result.Name == null) { return NotFound("Product not found"); }
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("Name                           |Quantity |   Price");
        builder.AppendLine($"{result.Name,-30} |{result.Quantity,8} | {result.Price,7}");

        return Ok(builder.ToString());
    }

    [HttpGet("Name Search")]
    public IActionResult NameSearch([FromQuery] string input)
    {
        List<Product> results = InventoryWorker.SearchByName(input);

        if (results.Count == 0)
        {
            return NotFound("No products found.");
        }
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("Name                           |Quantity |   Price");
        foreach (Product result in results)
        {
            builder.AppendLine($"{result.Name,-30} |{result.Quantity,8} | {result.Price,7}");
        }
        return Ok(builder.ToString());
    }
}