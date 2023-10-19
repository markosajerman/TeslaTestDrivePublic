using VehicleApi.Models;

namespace VehicleApi.Interfaces
{
    // Interface used for service methods
    public interface IVehicle
    {
        // Method for returning list of Vehicles
        Task<List<Vehicle>> GetAllVehicles();
        // Method for returning Vehicle by id
        Task<Vehicle> GetVehicleById(int id);
        // Method for adding a new Vehicle
        Task AddVehicle(Vehicle vehicle);
        // Method for updating a Vehicle
        Task UpdateVehicle(int id, Vehicle vehicle);
        // Method for deleting a Vehicle
        Task DeleteVehicle(int id);
    }
}
