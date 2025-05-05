using EShopService;
using EShop.Domain.Repositories;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EShop.Domain.Models;
using System.Net.Http.Json;


namespace EShopService.IntegrationTests;

public class ProductControllerIntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient _httpClient;
    private WebApplicationFactory<Program> _factory;
    public ProductControllerIntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // Previous DB configuration
                    var dbContextOptions = services
                        .SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<DataContext>));

                    // Deletion of the previous DB configuration
                    services.Remove(dbContextOptions!);

                    // New database
                    services
                        .AddDbContext<DataContext>(options => options.UseInMemoryDatabase("TestDB"));

                });
            });
        _httpClient = _factory.CreateClient();
    }

    [Fact]
    public async Task Get_ReturnsEverything_ReturnsOKStatusCode()
    {
        // Arrange
        using (var scope = _factory.Services.CreateScope())
        {
            // Pobranie kontekstu bazy danych
            var dbContext = scope.ServiceProvider.GetRequiredService<DataContext>();

            dbContext.Products.RemoveRange(dbContext.Products);

            // Stworzenie obiektu
            dbContext.Products.AddRange(
                new Product { Name = "Test plushie 1" },
                new Product { Name = "Test matcha 2" },
                new Product { Name = "Test powerbank 3" },
                new Product { Name = "Test tee 4" }
            );
            // Zapisanie obiektu
            await dbContext.SaveChangesAsync();
        }
        bool okRequest = true;

        // Act
        var response = await _httpClient.GetAsync("/api/product");

        // Assert
        try
        {
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException)
        {
            okRequest = false;
        }
        finally
        {
            var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            Assert.True(okRequest);
            Assert.Equal(4, products?.Count);
        }
    }
}