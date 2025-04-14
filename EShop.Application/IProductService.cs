using EShop.Domain.Models;
using EShop.Domain.Repositories;

namespace EShop.Application;

public interface IProductService
{
    public void Add(Repository repository, Product product);
    public void Update(Repository repository, Product product);
    public void Delete(Repository repository, int id);
    public Product GetById(int id);
    public IEnumerable<Product> GetAll(Repository repository);
}
