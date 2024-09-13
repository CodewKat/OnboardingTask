using Microsoft.EntityFrameworkCore;

namespace OnboardingTask.Server.Models
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasKey(e => e.Customer_Id).HasName("PK_Customer");

            modelBuilder.Entity<Customer>()
                .ToTable("Customer");
            
            base.OnModelCreating(modelBuilder);
        }

    }
}
