using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Dynamic.Core;
using ConsoleAppDynamicLinq.Models;

namespace ConsoleAppDynamicLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var context = new TestDbContext();
                context.Brands.RemoveRange(context.Brands);
                context.Products.RemoveRange(context.Products);
                context.SaveChanges();

                var brand1 = new Brand
                {
                    Name = "Brand 1"
                };

                var brand2 = new Brand
                {
                    Name = "Brand 2"
                };

                var brands = new List<Brand>
                {
                    brand1,
                    brand2
                };

                context.Brands.AddRange(brands);

                context.SaveChanges();

                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "Product 1",
                        BrandId = brand1.Id,
                        State = 0
                    },
                    new Product
                    {
                        Name = "Product 2",
                        BrandId = brand2.Id,
                        State = 1
                    }
                };

                context.Products.AddRange(products);
                context.SaveChanges();
                
                var query = context.Brands.Select(b => new BrandModelWithStats
                {
                    Id = b.Id,
                    Name = b.Name,
                    BrandStat = new BrandStat
                    {
                        ProductCount = context.Products.Count(p => p.BrandId == b.Id),
                        PublishedProductCount = context.Products.Count(p => p.BrandId == b.Id && p.State == 1)
                    }
                });

                //query = query.OrderBy("BrandStat.ProductCount");
                query = query.OrderBy("np(BrandStat.ProductCount)");

                var result = query.ToList();

                Console.WriteLine(result.Count);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
    }

    

    
}
