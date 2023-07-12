using Microsoft.AspNetCore.Mvc;
using RM.Entities;
using RM.Interfaces;
using RM.Services;
using System.Threading.Tasks;

namespace RM.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MenuController : Controller
	{
		private readonly IMenuService _menuService;

		public MenuController(IMenuService menuService)
		{
			_menuService = menuService;
		}

		[HttpGet]
		public Task<List<Menu>> GetMenuItems()
		{
			var menu = _menuService.GetMenuItems();
			return menu;
		}

		[HttpGet]
		[Route("{id}")]
		public Task<Menu> GetMenuItem(int id)
		{
			var menuItem = _menuService.GetMenuItemById(id);
			return menuItem;
		}

		[HttpPost]
		public Task<Menu> Create(Menu menuItem)
		{
			var newMenuItem = _menuService.CreateMenuItem(menuItem);
			return newMenuItem;
		}

		[HttpPut]
		public Task<Menu> Update(Menu menuItem)
		{
			var updatedMenuItem = _menuService.UpdateMenuItem(menuItem);
			return updatedMenuItem;
		}

		[HttpDelete]
		public Task Delete(int id)
		{
			return _menuService.DeleteMenuItem(id);
		}
	}
}