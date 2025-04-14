using Microsoft.EntityFrameworkCore;
using EShop.Domain.Models;
using EShop.Domain.Repositories;

namespace EShop.Domain.Seeders;

public interface IEShopSeeder
{
    public async Task Seed(DataContext context) { }
}
