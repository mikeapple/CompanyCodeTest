using Company.Common.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace Company.Database
{
    public class CompanyContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }
        public DbSet<QuoteType> QuoteTypes { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<VehicleQuote> VehicleQuotes { get; set; }

        public CompanyContext(DbContextOptions<CompanyContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Make>(e =>
            {
                e.ToTable("Make");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id);
                e.Property(e => e.Text);
            });

            modelBuilder.Entity<QuoteType>(e =>
            {
                e.ToTable("QuoteType");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id);
                e.Property(e => e.Text);
            });


            modelBuilder.Entity<VehicleType>(e =>
            {
                e.ToTable("VehicleType");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id);
                e.Property(e => e.Text);
            });


            modelBuilder.Entity<VehicleQuote>(e =>
            {
                e.ToTable("VehicleQuote");
                e.HasKey(e => e.Id);
                e.Property(e => e.Id);
                e.Property(e => e.MakeId);
                e.Property(e => e.VehicleTypeId);
                e.Property(e => e.QuoteTypeId);
                e.Property(e => e.ZeroToThreeMonthsApr);
                e.Property(e => e.ThreeToSixMonthsApr);
                e.Property(e => e.SixToTwelveMonthsApr);
                e.Property(e => e.OverTwelveMonthsApr);

            });
        }

    }
}
