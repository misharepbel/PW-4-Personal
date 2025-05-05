using EShop.Domain.Models;
using EShop.Domain.Repositories;

namespace EShop.Application;

public class ProductService : IProductService
{
    private IRepository _repo;
    public ProductService(IRepository repo)
    {
        _repo = repo;
    }

    public async Task<Product> AddAsync(Product product)
    {
        return await _repo.AddAsync(product);
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        return await _repo.UpdateAsync(product);
    }
}
