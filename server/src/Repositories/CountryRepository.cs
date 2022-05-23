using System.Collections.Generic;
using System.Linq;
using Server.Models;
using Server.Interfaces;

namespace Server.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly List<Country> countries;

        public CountryRepository()
        {
            countries = new List<Country>{
                new Country{
                    Name = "Australia",
                    ConversationRate = 1m,
                    Currency = "AUD"
                },
                new Country{
                    Name = "New Zealand",
                    ConversationRate = 1.10m,
                    Currency = "NZD"
                },
                new Country{
                    Name = "Singapore",
                    ConversationRate = 0.97m,
                    Currency = "SGD"
                }
            };
        }

        public List<Country> GetCountries()
        {
            return this.countries;
        }
    }
}