using Microsoft.AspNetCore.Mvc;
using store_stock_tracker.src.Tools;
using store_stock_tracker.src.WebAPI.Utils;
using System.Text;

[ApiController]
[Route("api/products")]
public class PublicAPIController : ControllerBase
{
    [HttpGet("SKU Search")]
    public IActionResult SKUSearch([FromQuery] string input)
    {
        Product result = Searcher.SearchBySKU(input);
        if (result.name == null) { return NotFound("Product not found"); }
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("Name                             |Quantity |   Price");
        builder.AppendLine($"{result.name,-30} |{result.quantity,8} | {result.price,7}");

        return Ok(builder.ToString);
    }

    [HttpGet("Name Search")]
    public IActionResult NameSearch([FromQuery] string input)
    {
        List<Product> results = Searcher.SearchByName(input);

        if (results.Count == 0)
        {
            return NotFound("No products found.");
        }
        StringBuilder builder = new StringBuilder();
        builder.AppendLine("Name                             |Quantity |   Price");
        foreach (Product result in results)
        {
            builder.AppendLine($"{result.name,-30} |{result.quantity,8} | {result.price,7}");
        }
        return Ok(builder.ToString());
    }
}