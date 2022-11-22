using Microsoft.EntityFrameworkCore;
using SimpleDiff.Models;

namespace SimpleDiff.Data
{
    public class DiffContext : DbContext
    {
        public DiffContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DiffItem>().HasKey(table => new { table.Id, table.Type });
        }

        public DbSet<DiffItem> DiffItems { get; set; } = null!;
    }
}
