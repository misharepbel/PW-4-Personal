using EShop.Domain.Models;
using EShop.Domain.Repositories;

namespace EShop.Application;

public interface IProductService
{
    void Add(Product product);
    void Update(int id, Product product);
    Product GetById(int id);
    IEnumerable<Product> GetAll();
}
