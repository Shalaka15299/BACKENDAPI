using BACKENDAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BACKENDAPI.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext>options):base(options)
        {

        }
        public DbSet<User> User { get; set; }

        public DbSet<ProductModel> productModels { get; set; }

        public DbSet<Ordermodel> orderModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<ProductModel>().ToTable("Products");
            modelBuilder.Entity<Ordermodel>().ToTable("Orders");
        }
    }
}
