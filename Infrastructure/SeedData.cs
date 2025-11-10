using Microsoft.EntityFrameworkCore;
using Etui.Models;

namespace Etui.Infrastructure
{
        public class SeedData
        {
                public static void SeedDatabase(DataContext context)
                {
                        context.Database.Migrate();

                        if (!context.Products.Any())
                        {
                                Category Samsung = new Category { Name = "Samsung", Slug = "Samsung" };
                                Category Apple = new Category { Name = "Apple", Slug = "apple" };
                                Category Xiaomi = new Category { Name = "Xiaomi", Slug = "xiaomi" };

                                context.Products.AddRange(
                                      
                                );

                                context.SaveChanges();
                        }
                }
        }
}