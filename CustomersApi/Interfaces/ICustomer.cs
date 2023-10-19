using CustomersApi.Models;

namespace CustomersApi.Interfaces
{
    // Interface used for service methods
    public interface ICustomer
    {
        // Method for returning a list of Customers
        Task<List<Customer>> GetAllCustomers();
        // Method for adding a new Customer
        Task AddCustomer(Customer customer);
        // Method for deleting a Customer
        Task DeleteCustomer(int id);
    }
}
