using RM.Entities;

namespace RM.Services
{
	public interface IMenuService
	{
        public Task<Menu> CreateMenuItem(Menu menuItem);

        public Task<Menu> GetMenuItemById(int id);

        public Task<List<Menu>> GetMenuItems();

        public Task<Menu> UpdateMenuItem(Menu menuItem);

        public Task DeleteMenuItem(int id);
	}
}