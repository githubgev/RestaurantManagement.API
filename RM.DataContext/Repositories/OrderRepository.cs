using Microsoft.EntityFrameworkCore;
using RM.Entities;
using RM.Interfaces;

namespace RM.Data.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		public RmDbContext _rmDbContext;

		public OrderRepository(RmDbContext rmDbContext)
		{
			_rmDbContext = rmDbContext;
		}

        public async Task<Order> CreateOrder(Order order)
		{
            var newOrder = await _rmDbContext.Order.AddAsync(order);
            await _rmDbContext.SaveChangesAsync();
            return newOrder.Entity;
        }

        public async Task DeleteOrder(int id)
		{
            var order = await _rmDbContext.Order.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (order is not null)
            {
                _rmDbContext.Order.Remove(order);
                await _rmDbContext.SaveChangesAsync();
            }
        }

        public async Task<Order> GetOrderById(int id)
		{
            var order = await _rmDbContext.Order.Where(p => p.Id == id).Include(o => o.OrderMenu).FirstOrDefaultAsync();
            return order;
        }

        public async Task<List<Order>> GetOrders()
		{
            return await _rmDbContext.Order.Include(o => o.OrderMenu).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByState(OrderState orderState)
		{
            var orders = await _rmDbContext.Order.Where(p => p.OrderStateId == (int)orderState).Include(o => o.OrderMenu).ToListAsync();
            return orders;
        }

        public async Task<Order> UpdateOrder(Order order)
		{
            var updatedProduct = _rmDbContext.Order.Update(order);
            await _rmDbContext.SaveChangesAsync();
            return updatedProduct.Entity;
        }
	}
}