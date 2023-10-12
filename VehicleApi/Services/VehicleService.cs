using Microsoft.EntityFrameworkCore;
using VehicleApi.Data;
using VehicleApi.Interfaces;
using VehicleApi.Models;

namespace VehicleApi.Services
{
    public class VehicleService : IVehicle
    {
        private ApiDbContext dbContext;
        public VehicleService()
        {
            dbContext = new ApiDbContext();   
        }
        public async Task AddVehicle(Vehicle vehicle)
        {
            await dbContext.Vehicles.AddAsync(vehicle);
            dbContext.SaveChangesAsync();
        }

        public async Task DeleteVehicle(int id)
        {
            var vehicle = await dbContext.Vehicles.FindAsync(id);
            dbContext.Vehicles.Remove(vehicle);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Vehicle>> GetAllVehicles()
        {
            var vehicles = await dbContext.Vehicles.ToListAsync();
            return vehicles;
        }

        public async Task<Vehicle> GetVehicleById(int id)
        {
            var vehicle = await dbContext.Vehicles.FindAsync(id);
            return vehicle;
        }

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
