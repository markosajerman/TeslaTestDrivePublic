using Azure.Messaging.ServiceBus;
using CustomersApi.Data;
using CustomersApi.Interfaces;
using CustomersApi.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CustomersApi.Services
{
    // Service extends ICustomer interface
    public class CustomerService : ICustomer
    {
        // With dbContext, data from ApiDbContext can be fetched
        private ApiDbContext dbContext;
        // Customers service constructor
        public CustomerService()
        {
            dbContext = new ApiDbContext();
        }

        // Service for returning a list of Customers
        public async Task<List<Customer>> GetAllCustomers()
        {
            var customers = await dbContext.Customers.ToListAsync();
            return customers; 
        }

        // Servce for adding a new Customer
        public async Task AddCustomer(Customer customer)
        {
            var vehicleInDb = await dbContext.Vehicles.FirstOrDefaultAsync(v => v.Id == customer.VehicleId);
            if (vehicleInDb == null) {
                await dbContext.Vehicles.AddAsync(customer.Vehicle);
                await dbContext.SaveChangesAsync();
            }
            customer.Vehicle = null;
            await dbContext.Customers.AddAsync(customer);
            await dbContext.SaveChangesAsync();

            // Add Code for Azure Messaging Bus
            // Strings provided for connecting to azure and queue on the service bus
            string connectionString = "Endpoint=sb://vehicletestdrivevs.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=r5oy3CKplzT0X8N3tJsEJnCj4h1WPcjn7+ASbKKJwo4=";
            string queueName = "azureorderqueue";
            // Adding Customer to service bus and serializing object to Json
            await using var client = new ServiceBusClient(connectionString);
            // Serializing object to Json
            var objectAsText = JsonConvert.SerializeObject(customer);

            ServiceBusSender sender = client.CreateSender(queueName);


            ServiceBusMessage message = new ServiceBusMessage(objectAsText);

            await sender.SendMessageAsync(message);
        }

        // Controller for deleting a Customer
        public async Task DeleteCustomer(int id)
        {
            var customer = await dbContext.Customers.FindAsync(id);
            dbContext.Remove(customer);
            await dbContext.SaveChangesAsync();
        }

        
    }
}
