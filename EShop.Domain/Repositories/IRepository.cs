// Interfejs repozytorium
using EShop.Domain.Models;

namespace EShop.Domain.Repositories;
public interface IRepository
{
    Task<IEnumerable<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<Product> AddAsync(Product product);
    Task<Product> UpdateAsync(Product product);
}