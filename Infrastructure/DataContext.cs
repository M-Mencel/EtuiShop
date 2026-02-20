using Etui.Enums;
using Etui.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Etui.Infrastructure
{
        public class DataContext : IdentityDbContext<IdentityUser>
        {
                public DataContext(DbContextOptions<DataContext> options) : base(options)
                { }
                public DbSet<Product> Products { get; set; }
                public DbSet<Category> Categories { get; set; }
        public object Dane { get; internal set; }
        public DbSet<Dane> Dane_1 { get; set; }
        public DbSet<Etui.Models.Support> Support { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public OrderStatus Status { get; set; }

        /*        protected override void OnModelCreating(ModelBuilder builder)
                {
                    builder.Entity<Order>()
                        .HasOne(cartItem-> );
                }*/
    }
}
