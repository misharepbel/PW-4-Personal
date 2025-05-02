// Interfejs repozytorium
using EShop.Domain.Models;

namespace EShop.Domain.Repositories;
public interface IRepository
{
    IEnumerable<Product> GetAll();
    Product GetById(int id);
    void Add(Product product);
    void Update(int id, Product product);
    void Delete(int id);
}