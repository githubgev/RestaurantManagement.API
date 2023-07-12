using Microsoft.EntityFrameworkCore;
using RM.Entities;
using RM.Interfaces;

namespace RM.Data.Repositories
{
	public class StorageRepository : IStorageRepository
	{
		public RmDbContext _rmDbContext;

		public StorageRepository(RmDbContext rmDbContext)
		{
			_rmDbContext = rmDbContext;
		}

		public async Task<Storage> CreateStorageItem(Storage item)
		{
            var newStorageItem = await _rmDbContext.Storage.AddAsync(item);
            await _rmDbContext.SaveChangesAsync();
            return newStorageItem.Entity;
        }

        public async Task DeleteStorageItem(int id)
		{
            var storageItem = await _rmDbContext.Storage.Where(p => p.Id == id).FirstOrDefaultAsync();
            if (storageItem is not null)
            {
                _rmDbContext.Storage.Remove(storageItem);
                await _rmDbContext.SaveChangesAsync();
            }
        }

        public async Task<Storage> GetStorageItemById(int id)
		{
            var storageItem = await _rmDbContext.Storage.Where(p => p.Id == id).FirstOrDefaultAsync();
            return storageItem;
        }

        public async Task<Storage> GetStorageItemByProductId(int productId)
        {
            var storageItem = await _rmDbContext.Storage.Where(p => p.ProductId == productId).FirstOrDefaultAsync();
            return storageItem;
        }

        public async Task<List<Storage>> GetStorageItems()
		{
            return await _rmDbContext.Storage.ToListAsync();
        }

        public async Task<Storage> UpdateStorageItem(Storage storageItem)
		{
            var updatedStorageItem = _rmDbContext.Storage.Update(storageItem);
            await _rmDbContext.SaveChangesAsync();
            return updatedStorageItem.Entity;
        }
	}
}