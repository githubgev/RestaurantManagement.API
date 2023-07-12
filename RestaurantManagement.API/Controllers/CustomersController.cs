using Microsoft.AspNetCore.Mvc;
using RM.Entities;
using RM.Services;

namespace RM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public Task<List<Customer>> GetCustomers()
        {
            var customers = _customerService.GetCustomers();
            return customers;
        }
    }
}