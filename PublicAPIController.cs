using Microsoft.AspNetCore.Mvc;
using store_stock_tracker.Data;
using store_stock_tracker.Models;
using store_stock_tracker.src.Cli.Utils;

[ApiController]
[Route("api/products")]
public class PublicAPIController : ControllerBase
{
    [HttpGet("SKU Search")]
    public IActionResult SKUSearch([FromQuery] string input)
    {
        var result = Searcher.APISearchBySKU(input);
        return Ok(result);
    }

    [HttpGet("Name Search")]
    public IActionResult NameSearch([FromQuery] string input)
    {
        var result = Searcher.APISearchByName(input);
        return Ok(result);
    }
}