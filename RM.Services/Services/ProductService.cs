using RM.Entities;
using RM.Interfaces;

namespace RM.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _productRepository;

		public ProductService(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public Task<Product> CreateProduct(Product product)
		{
			var newProduct = _productRepository.CreateProduct(product);
			return newProduct;
		}

		public Task DeleteProduct(int id)
		{
			return _productRepository.DeleteProduct(id);
		}

		public Task<Product> GetProductById(int id)
		{
			var product = _productRepository.GetProductById(id);
			return product;
		}

		public Task<Product> UpdateProduct(Product product)
		{
			var updatedProduct = _productRepository.UpdateProduct(product);
			return updatedProduct;
		}

		public async Task<List<Product>> GetProducts()
		{
			var products = await _productRepository.GetProducts();
			return products;
		}
	}
}