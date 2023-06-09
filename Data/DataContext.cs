using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Products.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products => Set<Product>();
        public DbSet<Review> Reviews => Set<Review>();
    }
}