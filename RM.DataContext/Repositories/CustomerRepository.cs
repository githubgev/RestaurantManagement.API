using Microsoft.EntityFrameworkCore;
using RM.Entities;
using RM.Interfaces;

namespace RM.Data.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		public RmDbContext _rmDbContext;

		public CustomerRepository(RmDbContext rmDbContext)
		{
			_rmDbContext = rmDbContext;
		}

		public async Task<List<Customer>> GetCustomers()
		{
			return await _rmDbContext.Customer.ToListAsync();
		}
	}
}