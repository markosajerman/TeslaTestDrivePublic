using Microsoft.EntityFrameworkCore;
using VehicleApi.Models;

namespace VehicleApi.Data
{
    // Added class for Entity Framework
    public class ApiDbContext : DbContext
    {
        // Adding DbSet properties for Vehicles
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=VehicleApiDb;Trusted_Connection=True");
        }
    }
}
