using DomainDrivenDesign.Domain.Abstractions;
using DomainDrivenDesign.Domain.Categories;
using DomainDrivenDesign.Domain.Orders;
using DomainDrivenDesign.Domain.Products;
using DomainDrivenDesign.Domain.Shared;
using DomainDrivenDesign.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace DomainDrivenDesign.Infrastructure.Context
{
    internal sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-KEM5IF3;Database=DomainDrivenDesign;User Id=sa;Password=123456;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// EntityFramework, objeleri anlayamadığı için obje içerisinde oluşturulan Value parametresini algılamasını sağlıyoruz.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User
            modelBuilder.Entity<User>()
                .Property(p => p.Name)
                .HasConversion(name => name.Value, value => new(value));

            modelBuilder.Entity<User>()
                .Property(p => p.Email)
                .HasConversion(email => email.Value, value => new(value));

            modelBuilder.Entity<User>()
                .Property(p => p.Password)
                .HasConversion(password => password.Value, value => new(value));

            modelBuilder.Entity<User>().OwnsOne(p => p.Address); // Adres objesi içerisinde kaç tane alan varsa onları tanımlıyor.
            #endregion

            #region Category 
            modelBuilder.Entity<Category>()
                .Property(p => p.Name)
                .HasConversion(name => name.Value, value => new(value));
            #endregion

            #region Product
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasConversion(name => name.Value, value => new(value));

            modelBuilder.Entity<Product>()
                .OwnsOne(p => p.Price, priceBuilder =>
                {
                    priceBuilder
                    .Property(p => p.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                    priceBuilder
                    .Property(p=> p.Amount)
                    .HasColumnType("money"); // Db'de money tipiyle tutması gerektiğini söylüyoruz.
                });
            #endregion

            #region OrderLine
            modelBuilder.Entity<OrderLine>()
                .OwnsOne(p => p.Price, priceBuilder =>
                {
                    priceBuilder
                    .Property(p => p.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                    priceBuilder
                    .Property(p => p.Amount)
                    .HasColumnType("money"); // Db'de money tipiyle tutması gerektiğini söylüyoruz.
                });
            #endregion
        }

        public Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
