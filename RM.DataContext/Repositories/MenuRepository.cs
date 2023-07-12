using Microsoft.EntityFrameworkCore;
using RM.Entities;
using RM.Interfaces;

namespace RM.Data.Repositories
{
	public class MenuRepository : IMenuRepository
	{
		public RmDbContext _rmDbContext;

		public MenuRepository(RmDbContext rmDbContext)
		{
			_rmDbContext = rmDbContext;
		}

		public async Task<Menu> CreateMenuItem(Menu menuItem)
		{
			var newMenuItem = await _rmDbContext.Menu.AddAsync(menuItem);
			await _rmDbContext.SaveChangesAsync();
			return newMenuItem.Entity;
		}

		public async Task DeleteMenuItem(int id)
		{
			var menuItem = await _rmDbContext.Menu.Where(p => p.Id == id).FirstOrDefaultAsync();
			if (menuItem is not null)
			{
				_rmDbContext.Menu.Remove(menuItem);
				await _rmDbContext.SaveChangesAsync();
			}
		}

		public async Task<Menu> GetMenuItemById(int id)
		{
			var menuItem = await _rmDbContext.Menu.Where(p => p.Id == id).Include(m => m.MenuProducts).Include(m => m.OrderMenu).FirstOrDefaultAsync();
			return menuItem;
		}

		public async Task<List<Menu>> GetMenuItems()
		{
			var menuItems = _rmDbContext.Menu;
			return await menuItems.Include(m => m.MenuProducts).Include(m => m.OrderMenu).ToListAsync();
		}

		public async Task<Menu> UpdateMenuItem(Menu menuItem)
		{
			var updatedStorageItem = _rmDbContext.Menu.Update(menuItem);
			await _rmDbContext.SaveChangesAsync();
			return updatedStorageItem.Entity;
		}
	}
}
