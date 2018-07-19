using Microsoft.EntityFrameworkCore;

namespace TestApp.Library.DataBase
{
    public class FabricContext : DbContext
    {
        public FabricContext(DbContextOptions<FabricContext> options)
            : base(options)
        { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Fabric> Fabrics { get; set; }
        public DbSet<Identifier> Identifiers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
            .HasIndex(p => new { p.CategoryCode })
            .IsUnique(true);

            modelBuilder.Entity<Fabric>()
            .HasIndex(p => new { p.FabricCode })
            .IsUnique(true);

            modelBuilder.Entity<Identifier>()
            .HasIndex(p => new { p.FabricId, p.CategoryId, p.IdentifierId})
            .IsUnique(true);
        }
    }
}
