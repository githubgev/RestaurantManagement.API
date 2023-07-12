using RM.Entities;

namespace RM.Interfaces
{
	public interface IOrderRepository
	{
		public Task<Order> CreateOrder(Order order);

		public Task<Order> GetOrderById(int id);

		public Task<List<Order>> GetOrdersByState(OrderState orderState);

		public Task<List<Order>> GetOrders();

		public Task<Order> UpdateOrder(Order order);

		public Task DeleteOrder(int id);
	}
}