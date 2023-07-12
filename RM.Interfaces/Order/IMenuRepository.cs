using RM.Entities;

namespace RM.Interfaces
{
    public interface IMenuRepository
    {
        public Task<Menu> CreateMenuItem(Menu menuItem);

        public Task<Menu> GetMenuItemById(int id);

        public Task<List<Menu>> GetMenuItems();

        public Task<Menu> UpdateMenuItem(Menu menuItem);

        public Task DeleteMenuItem(int id);
    }
}