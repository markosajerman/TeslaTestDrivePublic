using CustomersApi.Models;

namespace CustomersApi.Interfaces
{
    public interface ICustomer
    {
        Task<List<Customer>> GetAllCustomers();
        Task AddCustomer(Customer customer);
        Task DeleteCustomer(int id);
    }
}
