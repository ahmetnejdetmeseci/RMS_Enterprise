using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Contexts
{
	public class Db : DbContext
	{
		

		public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<UserProduct> UserProducts { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<SaleProduct> SaleProducts { get; set; }

        public Db(DbContextOptions<Db> options) : base(options) 
        { 
            
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			modelBuilder.Entity<UserProduct>().HasKey(userProduct => new { userProduct.UserId, userProduct.ProductId });

			modelBuilder.Entity<SaleProduct>().HasKey(saleProduct => new { saleProduct.ProductId, saleProduct.SaleId });

			modelBuilder.Entity<UserProduct>().HasOne(userProduct => userProduct.User)
				.WithMany(user => user.UserProducts)
				.HasForeignKey(userProduct => userProduct.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<UserProduct>().HasOne(userProduct => userProduct.Product)
				.WithMany(product => product.UserProducts)
				.HasForeignKey(userProduct => userProduct.ProductId)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<SaleProduct>().HasOne(saleProduct => saleProduct.Product)
				.WithMany(product => product.SaleProducts)
				.HasForeignKey(saleProduct => saleProduct.ProductId)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<SaleProduct>().HasOne(saleProduct => saleProduct.Sale)
				.WithMany(sale =>  sale.SaleProducts)
				.HasForeignKey(saleProduct => saleProduct.SaleId)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
		}

	}
}
