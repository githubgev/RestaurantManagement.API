using RM.Entities;
using RM.Interfaces;

namespace RM.Services
{
    public class StorageService : IStorageService
	{
        private readonly IStorageRepository _storageRepository;

        public StorageService(IStorageRepository storageRepository) 
		{
			_storageRepository = storageRepository;
        }

        public Task<Storage> CreateStorageItem(Storage item)
		{
            var newStorageItem = _storageRepository.CreateStorageItem(item);
            return newStorageItem;
        }

        public Task DeleteStorageItem(int id)
		{
            return _storageRepository.DeleteStorageItem(id);

        }

        public Task<Storage> GetStorageItemById(int id)
		{
            var storageItem = _storageRepository.GetStorageItemById(id);
            return storageItem;
        }

        public async Task<List<Storage>> GetStorageItems()
		{
            var storageItems = await _storageRepository.GetStorageItems();
            return storageItems;
        }

        public Task<Storage> UpdateStorageItem(Storage item)
		{
            var updatedStorageItem = _storageRepository.UpdateStorageItem(item);
            return updatedStorageItem;
        }
	}
}