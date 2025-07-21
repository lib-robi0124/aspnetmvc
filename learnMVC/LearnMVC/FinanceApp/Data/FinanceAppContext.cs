using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data
{
    public class FinanceAppContext : DbContext
    {
        public FinanceAppContext(DbContextOptions<FinanceAppContext> options)
            : base(options)
        {
        }
        public DbSet<Expence> Expences { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FinanceApp.Models.Expence>().ToTable("Expences");
            base.OnModelCreating(modelBuilder);
        }
    }
}
