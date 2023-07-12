using RM.Entities;

namespace RM.Services
{
	public interface IUserService
	{
		public Task<List<User>> GetUsers();

		public Task<List<UserHistory>> GetUsersHistory();
	}
}