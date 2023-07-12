using Microsoft.EntityFrameworkCore;
using RM.Entities;

public static class ModelBuilderExtensions
{
	public static ModelBuilder ApplyConfigurations(this ModelBuilder builder)
	{
		builder.ApplyConfigurationsFromAssembly(typeof(ModelBuilderExtensions).Assembly);

		builder.Entity<MenuProduct>()
			.HasKey(mp => new { mp.MenuId, mp.ProductId });

		builder.Entity<OrderMenu>()
			.HasKey(om => new { om.OrderId, om.MenuId });

		return builder;
	}
}