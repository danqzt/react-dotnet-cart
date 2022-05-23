using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product? GetById(string id);
        void UpdateStock(Product product, int quantity);
    }
}