using Microsoft.EntityFrameworkCore;
using VehicleApi.Data;
using VehicleApi.Interfaces;
using VehicleApi.Models;

namespace VehicleApi.Services
{
    // Service extends IReservations interface
    public class VehicleService : IVehicle
    {
        // With dbContext, data from ApiDbContext can be fetched
        private ApiDbContext dbContext;
        // Vehicles service constructor
        public VehicleService()
        {
            dbContext = new ApiDbContext();   
        }

        // Service for adding a Vehicle
        public async Task AddVehicle(Vehicle vehicle)
        {
            await dbContext.Vehicles.AddAsync(vehicle);
            dbContext.SaveChangesAsync();
        }

        // Service for deleting a Vehicle
        public async Task DeleteVehicle(int id)
        {
            var vehicle = await dbContext.Vehicles.FindAsync(id);
            dbContext.Vehicles.Remove(vehicle);
            await dbContext.SaveChangesAsync();
        }

        // Service for returning a list of Vehicles
        public async Task<List<Vehicle>> GetAllVehicles()
        {
            var vehicles = await dbContext.Vehicles.ToListAsync();
            return vehicles;
        }

        // Service for getting a Vehicle by id
        public async Task<Vehicle> GetVehicleById(int id)
        {
            var vehicle = await dbContext.Vehicles.FindAsync(id);
            return vehicle;
        }

        // Service for updating a Vehicle
        public async Task UpdateVehicle(int id, Vehicle vehicle)
        {
            var vehicleObj = await dbContext.Vehicles.FindAsync(id);
            vehicleObj.Name = vehicle.Name;
            vehicleObj.ImageUrl = vehicle.ImageUrl;
            vehicleObj.Price = vehicle.Price;
            vehicleObj.Width = vehicle.Width;
            vehicleObj.Height = vehicle.Height;
            vehicleObj.Displacement = vehicle.Displacement; 
            vehicleObj.MaxSpeed = vehicle.MaxSpeed;
            await dbContext.SaveChangesAsync();
        }
    }
}
