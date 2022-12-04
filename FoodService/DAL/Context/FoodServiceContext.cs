using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class FoodServiceContext:DbContext
    {
        public DbSet<Food>? Foods { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<OrderItem>?OrderItems { get; set; }
        public DbSet<History>? Histories { get; set; }
        public DbSet<Subcategory>? Subcategories { get; set; }

        public FoodServiceContext(DbContextOptions<FoodServiceContext>options):
            base(options)
        {
            Database.EnsureCreated();
        }

    }
}
