using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Etui.Models;
using Microsoft.AspNetCore.Identity;

namespace Etui.Infrastructure
{
        public class DataContext : IdentityDbContext<IdentityUser>
        {
                public DataContext(DbContextOptions<DataContext> options) : base(options)
                { }
                public DbSet<Product> Products { get; set; }
                public DbSet<Category> Categories { get; set; }
        public object Dane { get; internal set; }
        public DbSet<Etui.Models.Dane> Dane_1 { get; set; }
        public DbSet<Etui.Models.Support> Support { get; set; }
    }
}
