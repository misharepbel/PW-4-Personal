using Microsoft.EntityFrameworkCore;
using EShop.Domain.Models;
using EShop.Domain.Repositories;

namespace EShop.Domain.Seeders;

public class EShopSeeder : IEShopSeeder
{
    public async Task Seed(DataContext context)
    {
        // Sprawdzenie czy tabela jest pusta
        if (!context.Products.Any())
        {
            var products = new List<Product>
            {
                new Product { Name = "Argo chain", Price = 185.99m },
                new Product { Name = "Flex tape", Price = 69.99m },
                new Product { Name = "John Paul II Dakimakura", Price = 159.99m }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
