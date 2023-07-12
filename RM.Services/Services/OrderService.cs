using RM.Entities;
using RM.Interfaces;

namespace RM.Services
{
	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IMenuService _menuService;

		public OrderService(IOrderRepository orderRepository, IMenuService menuService)
		{
			_orderRepository = orderRepository;
			_menuService = menuService;

		}

		public Task<Order> CreateOrder(Order order)
		{
			order.OrderStateId = (int)OrderState.Pending;
			var newOrder = _orderRepository.CreateOrder(order);
			return newOrder;
		}

		public Task DeleteOrder(int id)
		{
			return _orderRepository.DeleteOrder(id);
		}

		public Task<Order> GetOrderById(int id)
		{
			var order = _orderRepository.GetOrderById(id);
			return order;
		}

		public Task<List<Order>> GetOrdersByState(OrderState orderState)
		{
			var orders = _orderRepository.GetOrdersByState(orderState);
			return orders;
		}

		public async Task<List<Order>> GetOrders()
		{
			var orders = await _orderRepository.GetOrders();
			return orders;
		}

		public Task<Order> UpdateOrder(Order order)
		{
			var updatedOrder = _orderRepository.UpdateOrder(order);
			return updatedOrder;
		}

		public async Task<Check> GetOrderCheckByOrderId(int id)
		{
			var order = await _orderRepository.GetOrderById(id);
			Check check = new Check() 
			{ 
				OrderDate = order.OrderDate, 
				Sum = order.Sum				
			};
			foreach (var orderMenu in order.OrderMenu)
			{
				var menuItem = await _menuService.GetMenuItemById(orderMenu.MenuId);
				check.Dishes.Add(new Dish()
				{
					Menu = menuItem,
					Count = orderMenu.Count
				}
				);
			}
			
			return check;
		}

		public async Task<List<Order>> GetUserOrders(int userId)
		{
			List<Order> userOrders = new List<Order>();
			var orders = await _orderRepository.GetOrders();
			if (orders is not null)
			{
				userOrders = orders.Where(o => o.UserId == userId).ToList();
			}
			return userOrders;
		}
	}
}