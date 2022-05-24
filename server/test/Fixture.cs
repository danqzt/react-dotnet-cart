using System.Linq.Expressions;
using Moq;
using Server.Models;
using System.Collections.Generic;
using Server.Interfaces;
using Server.Services;
using Server.Repositories;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace Test;
public class TestFixture
{
    public Mock<IProductRepository> ProductRepoMock = new Mock<IProductRepository>();
    public Mock<ICountryRepository> CountryRepoMoc = new Mock<ICountryRepository>();

    public TestFixture()
    {
        var products = new List<Product>{
            new Product{
               Id="A",
               Name="Product A",
               Price=1m,
            },
            new Product{
                Id="B",
                Name="Product B",
                Price=3m
            },
            new Product{
                Id="C",
                Name="Product C",
                Price=5m
            }
        };

        var countries = new List<Country>{
            new Country{
                Name="Country A",
                ConversationRate = 1
            },
            new Country{
                Name="Country B",
                ConversationRate = 2
            }
        };

        ProductRepoMock.Setup(p => p.GetProducts()).Returns(products);
        ProductRepoMock.Setup(p => p.GetById(It.IsAny<string>())).Returns((string id) => products.First(p => p.Id == id));
        CountryRepoMoc.Setup( c=> c.GetCountries()).Returns(countries);
    }

    public CartService CartService => new (new CartRepository(CountryRepoMoc.Object), 
                                           new Mock<ILogger<CartService>>().Object);
}