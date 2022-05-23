using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Models;
using Server.Services;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class ShopController : ControllerBase
{
    private readonly ILogger<ShopController> logger;
    private IShopService shopSvc;
    public ShopController(ILogger<ShopController> logger, IShopService shopSvc)
    {
        this.logger = logger;
        this.shopSvc = shopSvc;
    } 

    [HttpGet("products")]
    public IActionResult GetProducts()
    {
        var products = shopSvc.GetProducts();
        return Ok(products);
    }
    
    [HttpGet("countries")]
    public IActionResult GetCountries()
    {
        var countries = shopSvc.GetCountries();
        return Ok(countries);
    }

}
