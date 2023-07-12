using Microsoft.AspNetCore.Mvc;
using RM.Entities;
using RM.Services;

namespace RM.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class StorageController : Controller
	{
		private readonly IStorageService _storageService;

		public StorageController(IStorageService storageService)
		{
			_storageService = storageService;
		}

		[HttpGet]
		public Task<List<Storage>> GetStorageItems()
		{
			var storage = _storageService.GetStorageItems();
			return storage;
		}

		[HttpGet]
		[Route("{id}")]
		public Task<Storage> GetStorageItem(int id)
		{
			var storageItem = _storageService.GetStorageItemById(id);
			return storageItem;
		}

		[HttpPost]
		public Task<Storage> Create(Storage storageItem)
		{
			var newStorageItem = _storageService.CreateStorageItem(storageItem);
			return newStorageItem;
		}

		[HttpPut]
		public Task<Storage> Update(Storage storageItem)
		{
			var updatedStorageItem = _storageService.UpdateStorageItem(storageItem);
			return updatedStorageItem;
		}

		[HttpDelete]
		public Task Delete(int id)
		{
			return _storageService.DeleteStorageItem(id);
		}
	}
}
