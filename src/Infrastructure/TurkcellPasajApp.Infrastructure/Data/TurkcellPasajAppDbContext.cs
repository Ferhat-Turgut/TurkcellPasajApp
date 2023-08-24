using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TurkcellPasajApp.Entities;

namespace TurkcellPasajApp.Infrastructure.Data
{
    public class TurkcellPasajAppDbContext : IdentityDbContext
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
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketProduct> BasketProducts { get; set; }


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

            //modelBuilder.Entity<OrderDetail>()
            //    .HasOne(od => od.OrderDetailsProduct)
            //    .WithMany()
            //    .HasForeignKey(od => od.OrderDetailsProductId)
            //    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<OrderDetail>()
                 .HasOne(od => od.OrderDetailsProduct)
                 .WithMany(p => p.OrderDetails) // Product ilişkisi ile dolduruldu
                 .HasForeignKey(od => od.OrderDetailsProductId)
                 .OnDelete(DeleteBehavior.Restrict);

     


            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Basket)
                .WithOne(b => b.Customer)
                .HasForeignKey<Basket>(b => b.CustomerId);

            modelBuilder.Entity<BasketProduct>()
                .HasKey(bp => new { bp.BasketId, bp.ProductId });

            modelBuilder.Entity<BasketProduct>()
                .HasOne(bp => bp.Basket)
                .WithMany(b => b.BasketProducts)
                .HasForeignKey(bp => bp.BasketId);

            modelBuilder.Entity<BasketProduct>()
                .HasOne(bp => bp.Product)
                .WithMany() 
                .HasForeignKey(bp => bp.ProductId);

           

        }

    }
}
