using Microsoft.EntityFrameworkCore;
using ReservationsApi.Models;

namespace ReservationsApi.Data
{
    // Added class for Entity Framework
    public class ApiDbContext : DbContext
    {
        // Added DbSet properties for Vehicles and Reservations
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ReservationApiDb;Trusted_Connection=True");
        }
    }
}
