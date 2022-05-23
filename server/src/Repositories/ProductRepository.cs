using System.Collections.Generic;
using System.Linq;
using Server.Interfaces;
using Server.Models;

namespace Server.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly Dictionary<string, Product> products;

        public ProductRepository()
        {
           #region construct products
            products = new Dictionary<string, Product>
            {
                {"prd-1", new Product
                {
                    Id = "prd-1",
                    Name = "Asus X25",
                    Description="ASUS TUF FX505DT Gaming Laptop- 15.6,120HzFullHD, AMD Ryzen5R5-3550 HProcessor,GeForce GTX1 650 Graphics, 8GBDDR4, 256GBPCIeSSD, RGBKeyboard, Windows1064-bit-FX505DT-AH51",
                    Price = 1950.00m,
                    Image = "https://m.media-amazon.com/images/I/81gK08T6tYL._AC_SL1500_.jpg",
                    StockQuantity = 5
                }},
                {"prd-2",new Product
                {
                    Id = "prd-2",
                    Name = "RazerBL1",
                    Description="Razer Blade 15 Base Gaming Laptop 2020 Intel Corei7-1075 0H6-Core, NVIDIAGeForceGTX1660Ti, 5.6FHD 1080p 120Hz, 16GBRAM, 256GBSSD, CNCA luminum, Chroma RGB Lighting, Black",
                    Image="https://m.media-amazon.com/images/I/71wF7YDIQkL._AC_SL1500_.jpg",
                    Price = 2200.00m,
                    StockQuantity = 5
                }},
                {"prd-3",new Product
                {
                    Id = "prd-3",
                    Name = "lenovo LG5",
                    Description="Lenovo Legion5 Gaming Laptop, 15.6 FHD (1920x1080) IPSScreen, 1AMD Ryzen 74800 HP rocessor, 16GBDDR4, 512GBSSD, NVIDIAG TX1660Ti, Windows10, 82B1000AUS, PhantomBlack",
                    Image="https://m.media-amazon.com/images/I/81w+3k4U8PL._AC_SL1500_.jpg",
                    Price = 1600.00M,
                    StockQuantity = 5
                }},
                {"prd-4",new Product
                {
                    Id = "prd-4",
                    Name = "msi g77",
                    Description="MSI GL66 Gaming Laptop: 15.6144Hz FHD 1080p Display, Intel Corei7-11800H, NVIDIA GeForce RTX3070, 16GB, 1512GBSSD, Win10, Black (11UGK-001)",
                    Image="https://m.media-amazon.com/images/I/61Ze2wc9nyS._AC_SL1500_.jpg",
                    Price = 1875.00M,
                    StockQuantity = 5
                }},
                {"prd-5",new Product
                {
                    Id = "prd-5",
                    Name = "Sony ",
                    Description="Soni Blade 15 Base Gaming Laptop 2020 Intel Corei7-1075 0H6-Core, NVIDIAGeForceGTX1660Ti, 5.6FHD 1080p 120Hz, 16GBRAM, 256GBSSD, CNCA luminum, Chroma RGB Lighting, Black",
                    Image="https://m.media-amazon.com/images/I/81gK08T6tYL._AC_SL1500_.jpg",
                    Price = 2200.00m,
                    StockQuantity = 5
                }},
                {"prd-6",new Product
                {
                    Id = "prd-6",
                    Name = "Mac",
                    Description="Mac Book 15 Base Gaming Laptop 2020 Intel Corei7-1075 0H6-Core, NVIDIAGeForceGTX1660Ti, 5.6FHD 1080p 120Hz, 16GBRAM, 256GBSSD, CNCA luminum, Chroma RGB Lighting, Black",
                    Image="https://m.media-amazon.com/images/I/71wF7YDIQkL._AC_SL1500_.jpg",
                    Price = 1400.00M,
                    StockQuantity = 5
                }},
                {"prd-7",new Product
                {
                    Id = "prd-7",
                    Name = "HP Pav",
                    Description="HP Horse Power Gaming Laptop: 15.6144Hz FHD 1080p Display, Intel Corei7-11800H, NVIDIA GeForce RTX3070, 16GB, 1512GBSSD, Win10, Black (11UGK-001)",
                    Image="https://m.media-amazon.com/images/I/61Ze2wc9nyS._AC_SL1500_.jpg",
                    Price = 1450.00M,
                    StockQuantity = 5
                }}
            };
            #endregion
        }
        public List<Product> GetProducts()
        {
            return products.Values.ToList();
        }
        
        public Product? GetById(string id)
        {
            if(!products.ContainsKey(id))
               return null;

            return products[id];
        }
        public void UpdateStock(Product product, int quantity)
        {
            products[product.Id].StockQuantity = quantity;
        }


    }
}