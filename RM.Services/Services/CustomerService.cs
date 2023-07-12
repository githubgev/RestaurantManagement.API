using RM.Entities;
using RM.Interfaces;

namespace RM.Services
{
    public class CustomerService : ICustomerService
	{
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            var customers = await _customerRepository.GetCustomers();
            return customers;
        }
    }
}