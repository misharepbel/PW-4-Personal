using Microsoft.EntityFrameworkCore;
using EShop.Domain.Models;
using Microsoft.Extensions.Options;

namespace EShop.Domain.Repositories;
public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }

    /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Połączenie z bazą danych
        optionsBuilder.UseSqlServer("Server=.;Database=MyDatabase;Trusted_Connection=True;");
    }*/
}