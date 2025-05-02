using Microsoft.EntityFrameworkCore;
using EShop.Domain.Models;
using EShop.Domain.Repositories;

namespace EShop.Domain.Seeders;

public class EShopSeeder(DataContext context) : IEShopSeeder
{
    public async Task Seed()
    {
        // Sprawdzenie czy tabela jest pusta
        if (!context.Products.Any())
        {
            var products = new List<Product>
            {
                new Product { Name = "Argo chain", Price = 185.99m, Ean = "5904610728954", SKU = "ARGOCHAINS" },
                new Product { Name = "Flex tape", Price = 69.99m, Ean = "0015714809534", SKU = "FLXTP"},
                new Product { Name = "John Paul II Dakimakura", Price = 159.99m, Ean = "6981805417968", SKU = "PAPAPILLOW" }
            };

            context.Products.AddRange(products);
            await context.SaveChangesAsync();
        }
    }
}
