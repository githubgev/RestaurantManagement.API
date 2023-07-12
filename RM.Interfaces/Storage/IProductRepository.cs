using RM.Entities;

namespace RM.Interfaces
{
    public interface IProductRepository
    {
        public Task<Product> CreateProduct(Product product);

        public Task<Product> GetProductById(int id);

        public Task<List<Product>> GetProducts();

        public Task<Product> UpdateProduct(Product product);

        public Task DeleteProduct(int id);
    }
}