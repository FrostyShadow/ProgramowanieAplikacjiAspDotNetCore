using AspDotNetAppsProgramming.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetAppsProgramming.Models
{
    public class ExchangesDbContext : DbContext
    {
        public ExchangesDbContext()
        {
            
        }

        public ExchangesDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<ItemEntity> Items { get; set; }
    }
}