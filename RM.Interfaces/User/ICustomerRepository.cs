using RM.Entities;

namespace RM.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<List<Customer>> GetCustomers();
    }
}