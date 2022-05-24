using Server.Interfaces;
using Server.Models;
using Server.Repositories;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Server.Services;

public class CartService : ICartService
{
    private readonly ILogger logger;
    private readonly ICartRepository cartRepo;

    public CartService(ICartRepository cartRepo, ILogger<CartService> logger)
    {
        this.cartRepo = cartRepo;
        this.logger = logger;
    }

    public Cart GetbyId(string id)
    {
        try
        {
            return cartRepo.GetById(id);
        }
        catch (Exception ex)
        {
            logger.LogError("CartService.GetById Error", id, ex);
            throw;
        }
    }
    public Cart Update(string cartName, CartItem cartItem)
    {
        try
        {
            var cart = GetbyId(cartName);
            var item = cart.Items.Where(i => i.Product.Id == cartItem.Product.Id).FirstOrDefault();
            if (item == null)
            {
                cart.Items.Add(cartItem);
            }
            else
            {
                if (item.Quantity == 0)
                {
                    cart.Items.Remove(item);
                }
                else
                {
                    item.Quantity += cartItem.Quantity;
                }

            }
            CalculatePrice(cart);
            cartRepo.Save(cart);

            return cart;
        }
        catch (Exception ex)
        {
            var payload = JsonSerializer.Serialize(cartItem);
            logger.LogError("CartService.Update Error", cartName, payload, ex);
            throw;
        }
    }

    public Cart Delete(string cartName, CartItem cartItem)
    {
        try
        {
            var cart = GetbyId(cartName);
            var item = cart.Items.Where(i => i.Product.Id == cartItem.Product.Id).FirstOrDefault();
            if (item != null)
            {
                cart.Items.Remove(item);
            }

            CalculatePrice(cart);
            cartRepo.Save(cart);

            return cart;
        }
        catch (Exception ex)
        {
            var payload = JsonSerializer.Serialize(cartItem);
            logger.LogError("CartService.Delete Error", cartName, payload, ex);
            throw;
        }
    }

    public Cart SetCountry(string cartName, Country country)
    {
        try
        {
            var cart = GetbyId(cartName);
            cart.Country = country;
            CalculatePrice(cart);
            cartRepo.Save(cart);
            return cart;
        }
        catch (Exception ex)
        {
            var payload = JsonSerializer.Serialize(country);
            logger.LogError("CartService.SetCountry Error", cartName, payload, ex);
            throw;
        }
    }

    private void CalculatePrice(Cart cart)
    {
        var totalPriceAUD = cart.Items.Sum(c => c.Product.Price * c.Quantity);
        cart.TotalPrice = totalPriceAUD * cart.Country.ConversationRate;
    }

}
