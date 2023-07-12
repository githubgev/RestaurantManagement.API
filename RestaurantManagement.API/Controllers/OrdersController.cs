using Microsoft.AspNetCore.Mvc;
using RM.Entities;
using RM.Services;

namespace RM.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrdersController : Controller
	{
		private readonly IOrderService _orderService;

		public OrdersController(IOrderService orderService)
		{
			_orderService = orderService;
		}

		[HttpGet]
		public Task<List<Order>> GetOrders()
		{
			var orders = _orderService.GetOrders();
			return orders;
		}

		[HttpGet]
		[Route("{id}")]
		public Task<Order> GetOrder(int id)
		{
			var order = _orderService.GetOrderById(id);
			return order;
		}

		[HttpGet]
		[Route("{id}/check")]
		public Task<Check> GetOrderCheck(int id)
		{
			var check = _orderService.GetOrderCheckByOrderId(id);
			return check;
		}

		[HttpPost]
		public Task<Order> Create(Order order)
		{
			var newOrder = _orderService.CreateOrder(order);
			return newOrder;
		}

		[HttpPut]
		public Task<Order> Update(Order order)
		{
			var updatedOrder = _orderService.UpdateOrder(order);
			return updatedOrder;
		}

		[HttpDelete]
		public Task Delete(int id)
		{
			return _orderService.DeleteOrder(id);
		}
	}
}