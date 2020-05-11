using DomainLayer;
using DomainLayer.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Configuration;

namespace PersistenceLayer
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = false;
            ChangeTracker.LazyLoadingEnabled = true;
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }
        public DbSet<InvoiceNumber> InvoiceNumbers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<WarehouseMovement> WarehouseMovements { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            ModelConfig(builder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new ApplicationUserConfig(modelBuilder.Entity<ApplicationUser>());
            new ClientConfig(modelBuilder.Entity<Client>());
            new InvoiceConfig(modelBuilder.Entity<Invoice>());
            new InvoiceDetailConfig(modelBuilder.Entity<InvoiceDetail>());
            new InvoiceNumberConfig(modelBuilder.Entity<InvoiceNumber>());
            new ProductConfig(modelBuilder.Entity<Product>());
            new WarehouseMovementConfig(modelBuilder.Entity<WarehouseMovement>());
        }
    }
}