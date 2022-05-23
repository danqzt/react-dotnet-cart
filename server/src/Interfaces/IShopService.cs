using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.Interfaces
{
    public interface IShopService
    {
        List<Product> GetProducts();

        List<Country> GetCountries();
    }
}