using RM.Entities;

namespace RM.Services
{
	public interface ICustomerService
	{
        public Task<List<Customer>> GetCustomers();
	}
}