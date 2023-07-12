using Microsoft.AspNetCore.Mvc;
using RM.Entities;
using RM.Services;

namespace RestaurantManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet]
		public Task<List<User>> GetUsers()
		{
			var users = _userService.GetUsers();
			return users;
		}

		[HttpGet]
		[Route("history")]
		public Task<List<UserHistory>> GetUsersHistory()
		{
			var usersHistory = _userService.GetUsersHistory();
			return usersHistory;
		}
	}
}