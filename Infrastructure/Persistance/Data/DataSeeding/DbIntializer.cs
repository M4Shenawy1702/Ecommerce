using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistance.Data.DataSeeding
{
    public class DbIntializer : IDbIntializer
    {
        private readonly AppDbContext _dbContext;

        public DbIntializer (AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task IntializeAsync()
        {
            try
            {
                //if (_dbContext.Database.GetPendingMigrations().Any())
                //{
                //    await _dbContext.Database.MigrateAsync();
                //}
                if (!_dbContext.productTypes.Any())
                {
                    // D:\Route\c#\08 asp.net api\Session_Demo\Infrastructure\Persistance\Data\DataSeeding\types.json
                    var typedata = await File.ReadAllTextAsync(@"..\Infrastructure\Persistance\Data\DataSeeding\types.json");
                    //convert json to c# object 
                    var type = JsonSerializer.Deserialize<List<ProductType>>(typedata);
                    if (type != null && type.Any())
                    {
                        await _dbContext.AddRangeAsync(type);
                        await _dbContext.SaveChangesAsync();
                    }
                }
                if (!_dbContext.productBrands.Any())
                {
                    // D:\Route\c#\08 asp.net api\Session_Demo\Infrastructure\Persistance\Data\DataSeeding\brands.json
                    var brandsdata = await File.ReadAllTextAsync(@"..\Infrastructure\Persistance\Data\DataSeeding\brands.json");
                    //convert json to c# object 
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsdata);
                    if (brands != null && brands.Any())
                    {
                        await _dbContext.productBrands.AddRangeAsync(brands);
                        await _dbContext.SaveChangesAsync();
                    }
                }
                if (!_dbContext.Products.Any())
                {
                    // D:\Route\c#\08 asp.net api\Session_Demo\Infrastructure\Persistance\Data\DataSeeding\Products.json
                    var productsdata = await File.ReadAllTextAsync(@"..\Infrastructure\Persistance\Data\DataSeeding\products.json");
                    //convert json to c# object 
                    var products = JsonSerializer.Deserialize<List<Product>>(productsdata);
                    if (products != null && products.Any())
                    {
                        await _dbContext.Products.AddRangeAsync(products);
                        await _dbContext.SaveChangesAsync();
                    }
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
            }
        }
    }
}
