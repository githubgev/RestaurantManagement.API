using RM.Entities;
using RM.Interfaces;

namespace RM.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IOrderService _orderService;

		public UserService(IUserRepository userRepository, IOrderService orderService) 
		{  
			_userRepository = userRepository;
			_orderService = orderService;
		}

		public async Task<List<User>> GetUsers()
		{
			var users = await _userRepository.GetUsers();
			return users;
		}

		public async Task<List<UserHistory>> GetUsersHistory()
		{
			var users = await _userRepository.GetUsers();
			List<UserHistory> usersHistoryList = new List<UserHistory>();
			foreach (var user in users) 
			{
				UserHistory userHistory = new UserHistory()
				{
					UserId = user.Id,
					Orders = await _orderService.GetUserOrders(user.Id)
				};
				usersHistoryList.Add(userHistory);
			}
			return usersHistoryList;
		}
	}
}