using RM.Entities;

namespace RM.Services
{
	public interface IStorageService
	{
        public Task<Storage> CreateStorageItem(Storage item);

        public Task<Storage> GetStorageItemById(int id);

        public Task<List<Storage>> GetStorageItems();

		public Task<Storage> UpdateStorageItem(Storage item);

        public Task DeleteStorageItem(int id);
	}
}