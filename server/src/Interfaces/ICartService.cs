using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.Interfaces
{
    public interface ICartService
    {
       Cart GetbyId(string id);
       Cart Update(string cartName, CartItem cartItem);
       Cart Delete(string cartName, CartItem cartItem);
       Cart SetCountry(string cartName, Country country);

    }
}