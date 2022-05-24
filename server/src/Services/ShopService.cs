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
    private ILogger logger;

    public ShopService(IProductRepository prdRepo, ICountryRepository countryRepo, ILogger<ShopService> logger)
    {
        this.productRepo = prdRepo;
        this.countryRepo = countryRepo;
        this.logger = logger;
    }
    public List<Product> GetProducts()
    {
        try
        {
            return productRepo.GetProducts();
        }
        catch (Exception ex)
        {
            logger.LogError("ShopService.GetProducts error", ex);
            throw;
        }
    }

    public List<Country> GetCountries()
    {
        try
        {
            return countryRepo.GetCountries();
        }
        catch (Exception ex)
        {
            logger.LogError("ShopService.GetCountries error", ex);
            throw;
        }
    }
}