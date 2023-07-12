using RM.Entities;

namespace RM.Interfaces
{
	public interface IStorageRepository
	{
		public Task<Storage> CreateStorageItem(Storage item);

		public Task<Storage> GetStorageItemById(int id);

		public Task<Storage> GetStorageItemByProductId(int productId);

		public Task<List<Storage>> GetStorageItems();

		public Task<Storage> UpdateStorageItem(Storage item);

		public Task DeleteStorageItem(int id);
	}
}