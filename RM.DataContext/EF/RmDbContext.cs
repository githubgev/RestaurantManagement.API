using Microsoft.EntityFrameworkCore;
using RM.Entities;

namespace RM.Data
{
	public class RmDbContext : DbContext
	{
		public RmDbContext(DbContextOptions<RmDbContext> options) : base(options) {}

		public DbSet<Menu> Menu { get; set; }

		public DbSet<Product> Product { get; set; }

		public DbSet<MenuProduct> MenuProduct { get; set; }

		public DbSet<Order> Order { get; set; }

		public DbSet<Storage> Storage { get; set; }

		public DbSet<User> User { get; set; }

		public DbSet<Customer> Customer { get; set; }
        
		public DbSet<OrderMenu> OrderMenu { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurations();
		}
	}
}