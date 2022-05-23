using System.Collections.Generic;
using Server.Interfaces;
using Server.Models;

namespace Server.Repositories
{
    public class CartRepository : ICartRepository
    {
        private ICountryRepository countryRepo;
        public CartRepository(ICountryRepository countryRepo)
        {
            this.countryRepo = countryRepo;
        }
        private Dictionary<string, Cart> cartTable = new Dictionary<string, Cart>();

        public Cart GetById(string Id)
        {
            if(!cartTable.ContainsKey(Id))
            {
              var cart = new Cart{
                  Id = Id,
                  Country = countryRepo.GetCountries().First(),
                  Items = new List<CartItem>()
              };
              cartTable.Add(Id, cart);
            }
            
            return cartTable[Id];
            
        }

        public void Save(Cart cart)
        {
           // do backend save
        }

    }
}