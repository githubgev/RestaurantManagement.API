using Microsoft.EntityFrameworkCore;
using RM.Entities;
using RM.Interfaces;

namespace RM.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public RmDbContext _rmDbContext;

        public UserRepository(RmDbContext rmDbContext)
        {
            _rmDbContext = rmDbContext;
        }

        public async Task<List<User>> GetUsers()
        {
            return await _rmDbContext.User.ToListAsync();
        }
    }
}