using System.Diagnostics;
using System;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Reflection.Metadata;
using Server.Repositories;
using Server.Models;
using Server.Repositories;
using Server.Interfaces;

namespace Server.Services;

public class ShopService : IShopService
{
    private IProductRepository productRepo;
    private ICountryRepository countryRepo;

    public ShopService(IProductRepository prdRepo, ICountryRepository countryRepo)
    {
        this.productRepo = prdRepo;
        this.countryRepo = countryRepo;
    }
    public List<Product> GetProducts()
    {
        return productRepo.GetProducts();
    }

    public List<Country> GetCountries()
    {
        return countryRepo.GetCountries();
    }
}