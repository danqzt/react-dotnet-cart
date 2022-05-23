using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Server.Interfaces;
using Server.Models;
using Server.Services;

namespace Server.Controllers;

[ApiController]
[Route("[controller]")]
public class CartController : ControllerBase
{

    private ICartService cartService;
    private readonly ILogger<CartController> _logger;

    public CartController(ILogger<CartController> logger, ICartService svc)
    {
        _logger = logger;
        this.cartService = svc;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var cart = cartService.GetbyId(CartId);
        return Ok(cart);
    }
    
    [HttpPost]
    public IActionResult Post(CartItem item)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var cart = cartService.Update(CartId, item);
        return Ok(cart);
    }
    
    [HttpDelete]
    public IActionResult Delete(CartItem item)
    {
        Console.WriteLine("Delete called");
        if (!ModelState.IsValid)
            return BadRequest();
        
        var cart = cartService.Delete(CartId, item);
        return Ok(cart);
    }

    [HttpPut("country")]
    public IActionResult Update(Country country)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var cart = cartService.SetCountry(CartId, country);
        return Ok(cart);
    }

    //Generate CartId using timestamp. In real world must associate with User context.
    private string CartId
    {
        get
        {
  
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("cartId")))
            {
                //this one wont work for http client in dev server
                //var generatedId = ((DateTimeOffset)DateTime.Now).ToUnixTimeMilliseconds().ToString();
                var generatedId = DateTime.Now.ToString("ddMMyyyy");
               // Console.WriteLine($"Generating Cart Id {generatedId}");
                HttpContext.Session.SetString("cartId", generatedId);
            }
            var cartId = HttpContext.Session.GetString("cartId");
            return cartId;
        }
    }

}
