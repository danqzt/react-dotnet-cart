using Server.Interfaces;
using Server.Models;
using Server.Repositories;

namespace Server.Services;

public class CartService : ICartService
{

    private readonly ICartRepository cartRepo;
    
    public CartService(ICartRepository cartRepo)
    {
        this.cartRepo = cartRepo;
    }
    
    public Cart GetbyId(string id)
    {
        return cartRepo.GetById(id);
    }
    public Cart Update(string cartName, CartItem cartItem)
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

    public Cart Delete(string cartName, CartItem cartItem)
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
    
    public Cart SetCountry(string cartName, Country country)
    {
        var cart = GetbyId(cartName);
        cart.Country = country;
        CalculatePrice(cart);
        cartRepo.Save(cart);
        return cart;
    }

    private void CalculatePrice(Cart cart)
    {
         var totalPriceAUD = cart.Items.Sum(c => c.Product.Price * c.Quantity);
         cart.TotalPrice = totalPriceAUD * cart.Country.ConversationRate;
    }

}
