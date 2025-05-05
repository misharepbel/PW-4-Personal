using EShop.Application;
using EShop.Domain.Models;
using EShopService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace EShopService.Tests.Controllers;

public class ProductControllerTests
{
    private readonly Mock<IProductService> _mockedProductService;
    private readonly ProductController _productController;

    public ProductControllerTests()
    {
        _mockedProductService = new Mock<IProductService>();
        _productController = new ProductController(_mockedProductService.Object);
    }

    [Fact]
    public async Task Get_NoArgs_ReturnsEverything_ReturnsOKStatusCode()
    {
        // Arrange
        var products = new List<Product> { new() { Id = 1}, new() { Id = 2 } };
        _mockedProductService.Setup(s =>  s.GetAllAsync()).ReturnsAsync(products);

        // Act
        var result = await _productController.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(products, okResult.Value);
    }
    [Fact]
    public async Task Get_Id_ValidID_ReturnsProduct_ReturnsOKStatusCode()
    {
        // Arrange
        var product = new Product { Id = 1 };
        _mockedProductService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(product);

        // Act
        var result = await _productController.Get(1);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(product, okResult.Value);
    }
    [Theory]
    [InlineData(-7)]
    [InlineData(999)]
    public async Task Get_Id_InvalidID_ReturnsNoProduct_Returns404StatusCode(int id)
    {
        // Arrange
        _mockedProductService.Setup(s => s.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Product)null);

        // Act
        var result = await _productController.Get(id);

        // Assert
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task Post_ValidProduct_ReturnsCreatedProduct()
    {
        // Arrange
        var newProduct = new Product();
        _mockedProductService.Setup(s => s.AddAsync(It.IsAny<Product>())).ReturnsAsync(newProduct);

        // Act
        var result = await _productController.Post(newProduct);

        // Assert
        _mockedProductService.Verify(s => s.AddAsync(newProduct), Times.Once);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Put_ValidProduct_UpdatesProduct_ReturnsOKStatusCode()
    {
        // Arrange
        var product = new Product { Id = 1 };
        _mockedProductService.Setup(s => s.UpdateAsync(product)).ReturnsAsync(product);

        // Act
        var result = await _productController.Put(1, product);

        // Assert
        _mockedProductService.Verify(s => s.UpdateAsync(product), Times.Once);
        Assert.IsType<OkObjectResult>(result);
    }

    [Fact]
    public async Task Delete_ValidId_MarksDeletedAndUpdates()
    {
        // Arrange
        var product = new Product { Id = 1, Deleted = false };
        _mockedProductService.Setup(s => s.GetByIdAsync(1)).ReturnsAsync(product);
        _mockedProductService.Setup(s => s.UpdateAsync(It.IsAny<Product>())).ReturnsAsync(product);

        // Act
        var result = await _productController.Delete(1);

        // Assert
        _mockedProductService.Verify(s => s.GetByIdAsync(1), Times.Once);
        _mockedProductService.Verify(s => s.UpdateAsync(It.Is<Product>(p => p.Deleted)), Times.Once);
        Assert.IsType<OkObjectResult>(result);
    }
}
