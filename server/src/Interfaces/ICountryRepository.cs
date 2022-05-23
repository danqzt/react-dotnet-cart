using System.Collections.Generic;
using System.Linq;
using Server.Models;

namespace Server.Interfaces
{
    public interface ICountryRepository
    {
        List<Country> GetCountries();
    }
}