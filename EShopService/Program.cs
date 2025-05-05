using EShop.Application;
using EShop.Domain.Repositories;
using EShop.Domain.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EShopService;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddScoped<IRepository, Repository>();

        builder.Services.AddScoped<ICreditCardService, CreditCardService>();

        builder.Services.AddScoped<IProductService, ProductService>();

        builder.Services.AddScoped<IEShopSeeder, EShopSeeder>();

        builder.Services.AddDbContext<DataContext>(options =>
            options.UseInMemoryDatabase("MyDatabase"));

        //var services = new ServiceCollection();
        //services.AddDbContext<DataContext>(options =>    options.UseInMemoryDatabase("MyDatabase"));


        var app = builder.Build();

        var scope = app.Services.CreateScope();
        var seeder = scope.ServiceProvider.GetRequiredService<IEShopSeeder>();
        await seeder.Seed();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}