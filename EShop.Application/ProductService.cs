using EShop.Domain.Models;
using EShop.Domain.Repositories;

namespace EShop.Application;

public class ProductService : IProductService
{
    public void Add(Repository repository, Product product) => repository.Add(product);

    public void Delete(Repository repository, int id)
    {
        repository.Delete(id);
    }

    public IEnumerable<Product> GetAll(Repository repository) => repository.GetAll();

    public Product GetById(Repository repository, int id)
    {
        return repository.GetById(id);
    }

    public void Update(Repository repository, Product product)
    {
        repository.Update(product);
    }
}
