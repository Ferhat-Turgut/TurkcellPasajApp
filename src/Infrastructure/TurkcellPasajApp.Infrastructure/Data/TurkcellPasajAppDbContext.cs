using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Infrastructure.Data
{
    public class TurkcellPasajAppDbContext:IdentityDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Seller> Sellers { get; set; }


        public TurkcellPasajAppDbContext(DbContextOptions<TurkcellPasajAppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>()
           .Property(p => p.Price)
           .HasColumnType("decimal(10, 2)");

            modelBuilder.Entity<CreditCard>()
            .Property(c => c.AvaibleBalance)
            .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.OrderProduct)
            .WithMany()
            .HasForeignKey(od => od.OrderProductId)
            .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
