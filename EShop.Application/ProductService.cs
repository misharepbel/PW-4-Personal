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

    public void Add(Product product) => _repo.Add(product);

    public IEnumerable<Product> GetAll() => _repo.GetAll();

    public Product GetById(int id)
    {
        return _repo.GetById(id);
    }

    public void Update(int id, Product product)
    {
        _repo.Update(id, product);
    }
}
