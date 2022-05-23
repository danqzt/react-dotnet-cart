using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.Interfaces
{
    public interface ICartRepository
    {
        Cart GetById(string Id);
        void Save(Cart cart);
    }
}