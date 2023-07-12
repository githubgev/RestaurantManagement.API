using Microsoft.EntityFrameworkCore;
using RM.Entities;
using RM.Interfaces;
using System.Reflection.Metadata;

namespace RM.Data.Repositories
{
	public class ProductRepository : IProductRepository
	{
		public RmDbContext _rmDbContext;

		public ProductRepository(RmDbContext rmDbContext)
		{
			_rmDbContext = rmDbContext;
		}

		public async Task<Product> CreateProduct(Product product)
		{
			var newProduct = await _rmDbContext.Product.AddAsync(product);
			await _rmDbContext.SaveChangesAsync();
			return newProduct.Entity;
		}

		public async Task DeleteProduct(int id)
		{
			var product = await _rmDbContext.Product.Where(p => p.Id == id).FirstOrDefaultAsync();
			if (product is not null)
			{
				_rmDbContext.Product.Remove(product);
				await _rmDbContext.SaveChangesAsync();
			}
		}

		public async Task<Product> GetProductById(int id)
		{
			var product = await _rmDbContext.Product.Where(p => p.Id == id).FirstOrDefaultAsync();

            var query = from b in _rmDbContext.Order
                        from p in _rmDbContext.OrderMenu
                        select new { b, p };

            return product;
		}

		public async Task<List<Product>> GetProducts()
		{
			return await _rmDbContext.Product.ToListAsync();
		}

		public async Task<Product> UpdateProduct(Product product)
		{
			var updatedProduct = _rmDbContext.Product.Update(product);
			await _rmDbContext.SaveChangesAsync();
			return updatedProduct.Entity;
		}
	}
}