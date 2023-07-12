using RM.Entities;

namespace RM.Services
{
	public interface IOrderService
	{
		public Task<Order> CreateOrder(Order order);

		public Task<Order> GetOrderById(int id);

		public Task<Check> GetOrderCheckByOrderId(int id);

		public Task<List<Order>> GetOrders();

		public Task<List<Order>> GetUserOrders(int userId);

		public Task<Order> UpdateOrder(Order order);

		public Task DeleteOrder(int id);
	}
}