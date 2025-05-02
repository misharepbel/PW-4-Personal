using EShop.Domain.Models;

namespace EShop.Domain.Repositories;

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

    public void Update(int id, Product product)
    {
        Product changedProduct = GetById(id);
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
