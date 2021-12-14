using ConsoleAppDynamicLinq.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDynamicLinq
{
    internal class TestDbContext : DbContext
    {
        public virtual DbSet<Brand> Brands { get; set; }

        public virtual DbSet<Product> Products { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ConsoleAppDynamicLinq,Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
