using EventBriteCatalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventBriteAssignment3A.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options): base(options)
        {

        }

        //Creation of tables
        public DbSet<CatalogCategory> CatalogCategories { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogLocation> CatalogLocations { get; set; }

        //Specify all models that will be build
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogCategory>(ConfigureCatalogCategory);
            modelBuilder.Entity<CatalogItem>(ConfigureCatalogItem);
            modelBuilder.Entity<CatalogLocation>(ConfigureCatalogLocation);
        }

        //Specifies how to build each model: Location, Item and brand tables. 
        //Specifies what properties are required.
                private void ConfigureCatalogItem(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("Catalog");
            builder.Property(c => c.EventId)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_hilo");

            builder.Property(c => c.EventName).IsRequired().HasMaxLength(50);

            builder.Property(c => c.Description).IsRequired().HasMaxLength(300);

            builder.Property(c => c.Price).IsRequired();

            builder.HasOne(c => c.Category).WithMany().HasForeignKey(c => c.CatalogCategoryId);

            builder.HasOne(c => c.Location).WithMany().HasForeignKey(c => c.CatalogLocationId);

            builder.Property(c => c.EventStartTime).IsRequired();

            builder.Property(c => c.EventEndTime).IsRequired();

        }

        private void ConfigureCatalogCategory(
            EntityTypeBuilder<CatalogCategory> builder)
        {
            builder.ToTable("CatalogCategories");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_category_hilo");

            builder.Property(c => c.Category).HasMaxLength(100);
        }

        private void ConfigureCatalogLocation(EntityTypeBuilder<CatalogLocation> builder)
        {
            builder.ToTable("CatalogLocation");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("catalog_location_hilo");

            builder.Property(c => c.Location)
                .HasMaxLength(100);
        }

    }
}
