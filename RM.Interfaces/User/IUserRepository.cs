using RM.Entities;

namespace RM.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetUsers();
    }
}