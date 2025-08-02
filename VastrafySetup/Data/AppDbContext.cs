using Microsoft.EntityFrameworkCore;
using VastrafySetup.Models;
using VastrafySetup.Models.Entities;

namespace VastrafySetup.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) { }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Style> Styles { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<CuttingEntry> CuttingEntries { get; set; }
        public DbSet<CuttingEntryDetail> CuttingEntryDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Size>().HasIndex(s => s.Name).IsUnique();

            modelBuilder.Entity<CuttingEntry>()
            .HasMany(e => e.SizeQuantities)
            .WithOne(sq => sq.CuttingEntry)
            .HasForeignKey(sq => sq.CuttingEntryId)
            .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
