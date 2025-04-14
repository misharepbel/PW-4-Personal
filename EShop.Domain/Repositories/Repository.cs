using EShop.Domain.Models;

namespace EShop.Domain.Repositories;

// Interfejs repozytorium
public interface IRepository
{
    IEnumerable<Product> GetAll();
    Product GetById(int id);
    void Add(Product product);
    void Update(Product product);
    void Delete(int id);
}

// Implementacja repozytorium
public class Repository : IRepository
{
    private readonly DataContext _context;

    public Repository(DataContext context)
    {
        _context = context;
    }

    public void Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var toDelete = GetById(id);
        toDelete.Deleted = true;
        _context.Products.Remove(toDelete);
        _context.SaveChanges();
    }

    public IEnumerable<Product> GetAll() => _context.Products.ToList();

    public Product GetById(int id)
    {
        return _context.Products.Where(x => x.Id == id).FirstOrDefault()!;
    }

    public void Update(Product product)
    {
        Product changedProduct = GetById(product.Id);
        changedProduct.Name = product.Name;
        changedProduct.Ean = product.Ean;
        changedProduct.Price = product.Price;
        changedProduct.Stock = product.Stock;
        changedProduct.SKU = product.SKU;
        changedProduct.Category = product.Category;
        changedProduct.Updated_at = DateTime.Now;
        _context.SaveChanges();
    }
}
