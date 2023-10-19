using CustomersApi.Interfaces;
using CustomersApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // _customerService field of a type ICustomer
        private ICustomer _customerService;
        // Injecting IReservation interface inside of a constructor
        public CustomersController(ICustomer customerService)
        {
            _customerService = customerService;
        }

        // Controller for returning a list of Customers
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            var customers = await _customerService.GetAllCustomers();
            return customers; 
        }

        // POST api/<CustomersController>
        // Controller for creating a new Customer
        [HttpPost]
        public async Task Post([FromBody] Customer customer)
        {
            await _customerService.AddCustomer(customer);
        }

        // Controller for deleting a Customer
        [HttpDelete("{id}")]

        public async Task Delete(int id)
        {
            await _customerService.DeleteCustomer(id);
        }

    }
}
