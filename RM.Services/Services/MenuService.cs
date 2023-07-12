using RM.Entities;
using RM.Interfaces;

namespace RM.Services
{
	public class MenuService : IMenuService
	{
		private readonly IMenuRepository _menuRepository;

		public MenuService(IMenuRepository menuRepository)
		{
			_menuRepository = menuRepository;
		}

		public Task<Menu> CreateMenuItem(Menu menuItem)
		{
			var newMenuItem = _menuRepository.CreateMenuItem(menuItem);
			return newMenuItem;
		}

		public Task DeleteMenuItem(int id)
		{
			return _menuRepository.DeleteMenuItem(id);
		}

		public Task<Menu> GetMenuItemById(int id)
		{
			var menuItem = _menuRepository.GetMenuItemById(id);
			return menuItem;
		}

		public async Task<List<Menu>> GetMenuItems()
		{
			var menu = await _menuRepository.GetMenuItems();
			return menu;
		}

		public Task<Menu> UpdateMenuItem(Menu menuItem)
		{
			var updatedMenuItem = _menuRepository.UpdateMenuItem(menuItem);
			return updatedMenuItem;
		}
	}
}