using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RM.Entities;
using RM.Interfaces;

namespace RM.Services.Services
{
	public class WorkerService : BackgroundService
	{
		private const int generalDelay = 5000;
		
		private readonly IOrderRepository _orderRepository;
		private readonly IStorageRepository _storageRepository;
		private readonly IMenuRepository _menuRepository;

		private SemaphoreSlim _processLock = new SemaphoreSlim(1);

		public WorkerService(IServiceScopeFactory factory)
		{
			_orderRepository = factory.CreateScope().ServiceProvider.GetRequiredService<IOrderRepository>();
			_storageRepository = factory.CreateScope().ServiceProvider.GetRequiredService<IStorageRepository>();
			_menuRepository = factory.CreateScope().ServiceProvider.GetRequiredService<IMenuRepository>();
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken)
		{
			while (!stoppingToken.IsCancellationRequested)
			{
				await Task.Delay(generalDelay, stoppingToken);
				await ProcessPendingOrders();
			}
		}

		private async Task ProcessPendingOrders()
		{
			await _processLock.WaitAsync();
			try
			{
				Console.WriteLine($"[{DateTime.Now.Minute}:{DateTime.Now.Second}] Started ProcessPendingOrders...");
				var pendingOrders = _orderRepository.GetOrdersByState(OrderState.Pending).Result;
				pendingOrders.OrderBy(o => o.OrderDate).ToList().ForEach(async o =>
				{
					if (await IsEnoughProductsInStorageForOrder(o))
					{
						await ResolveStorage(o);
						SetOrderState(o, OrderState.Processing);
					}
					else
					{
						SetOrderState(o, OrderState.Rejected);
					}
				});
				Console.WriteLine($"[{DateTime.Now.Minute}:{DateTime.Now.Second}] Completed ProcessPendingOrders.");
			}
			finally
			{
				_processLock.Release();
			}
		}

		private void SetOrderState(Order o, OrderState orderState)
		{
			o.OrderStateId = (int)orderState;
			_orderRepository.UpdateOrder(o);
		}

		private async Task ResolveStorage(Order o)
		{
			foreach (var orderMenuItem in o.OrderMenu)
			{
				var menuItem = await _menuRepository.GetMenuItemById(orderMenuItem.MenuId);
				int countInOrder = orderMenuItem.Count;

				foreach (var menuProduct in menuItem.MenuProducts)
				{
					var storageItem = await _storageRepository.GetStorageItemByProductId(menuProduct.ProductId);
					storageItem.Quantity -= countInOrder;
					await _storageRepository.UpdateStorageItem(storageItem);
				}
			}

			return;
		}

		private async Task<bool> IsEnoughProductsInStorageForOrder(Order o)
		{
			foreach (var orderMenuItem in o.OrderMenu)
			{
				var menuItem = await _menuRepository.GetMenuItemById(orderMenuItem.MenuId);
				int countInOrder = orderMenuItem.Count;

				foreach (var menuProduct in menuItem.MenuProducts)
				{
					var storageItem = await _storageRepository.GetStorageItemByProductId(menuProduct.ProductId);
					if (storageItem.Quantity < countInOrder)
					{
						return false;
					}
				}
			}           

			return true;
		}
	}
}