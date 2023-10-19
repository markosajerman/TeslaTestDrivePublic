using Microsoft.EntityFrameworkCore;
using CustomersApi.Models;

namespace CustomersApi.Data
{
    // Added class for Entity Framework
    public class ApiDbContext : DbContext
    {
        // Added DbSet properties for Vehicles and Customers
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=CustomerApiDb;Trusted_Connection=True");
        }
    }
}
