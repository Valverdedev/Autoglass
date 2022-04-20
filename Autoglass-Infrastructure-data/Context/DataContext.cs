using Autoglass_Domain.Entities;
using Autoglass_Infrastructure_data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Autoglass_Infrastructure_data.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DataContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { 
            if (!optionsBuilder.IsConfigured) 
            {
                optionsBuilder.UseSqlite("Data Source=data.db;");
            } 
        
        }
      

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }

    }
}
