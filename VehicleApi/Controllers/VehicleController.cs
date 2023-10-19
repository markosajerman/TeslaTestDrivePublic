using Microsoft.AspNetCore.Mvc;
using VehicleApi.Interfaces;
using VehicleApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VehicleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        // _vehicleService field of a type IVehicle
        private IVehicle _vehicleService;
        // Injecting IVehicle interface inside of a constructor
        public VehicleController(IVehicle vehicleService)
        {
            _vehicleService = vehicleService;
        }
        // GET: api/<VehicleController>
        // Controller for returning a list of Vehicles
        [HttpGet]
        public async Task<IEnumerable<Vehicle>> Get()
        {
             var vehicles = await _vehicleService.GetAllVehicles();
            return vehicles;
        }

        // GET api/<VehicleController>/5
        // Controller for returning a Vehicle by id
        [HttpGet("{id}")]
        public async Task<Vehicle> Get(int id)
        {
            return await _vehicleService.GetVehicleById(id);
        }

        // POST api/<VehicleController>
        // Controller for creating a new Vehicle
        [HttpPost]
        public async Task Post([FromBody] Vehicle vehicle)
        {
            await _vehicleService.AddVehicle(vehicle);
        }

        // PUT api/<VehicleController>/5
        // Controller for updating a Vehicle
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Vehicle vehicle)
        {
            await _vehicleService.UpdateVehicle(id, vehicle);
        }

        // DELETE api/<VehicleController>/5
        // Controller for deleting a Vehicle
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _vehicleService.DeleteVehicle(id);
        }
    }
}
