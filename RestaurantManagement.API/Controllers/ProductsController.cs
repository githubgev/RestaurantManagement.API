using Microsoft.AspNetCore.Mvc;
using RM.Entities;
using RM.Services;

namespace RM.API.Controllers
{
    [ApiController]
	[Route("api/[controller]")]
	public class ProductsController : Controller
	{
		private readonly IProductService _productService;

		public ProductsController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public Task<List<Product>> GetProducts()
		{
			var products = _productService.GetProducts();
			return products;
		}

		[HttpGet]
		[Route("{id}")]
		public Task<Product> GetProduct(int id)
        {
			var product = _productService.GetProductById(id);
			return product;
		}

		[HttpPost]
		public Task<Product> Create(Product product)
		{
			var newProduct = _productService.CreateProduct(product);
			return newProduct;
		}

		[HttpPut]
		public Task<Product> Update(Product product)
		{
			var updatedProduct = _productService.UpdateProduct(product);
			return updatedProduct;
		}

		[HttpDelete]
		public Task Delete(int id)
		{
			return _productService.DeleteProduct(id);
		}
	}
}