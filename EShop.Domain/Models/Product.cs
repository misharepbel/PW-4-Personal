namespace EShop.Domain.Models;

public class Product : BaseModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Ean { get; set; } = default!;
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string SKU { get; set; } = default!;
    public Category Category { get; set; } = default!;
}
