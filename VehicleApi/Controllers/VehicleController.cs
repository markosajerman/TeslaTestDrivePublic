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
        private IVehicle _vehicleService;
        public VehicleController(IVehicle vehicleService)
        {
            _vehicleService = vehicleService;
        }
        // GET: api/<VehicleController>
        [HttpGet]
        public async Task<IEnumerable<Vehicle>> Get()
        {
             var vehicles = await _vehicleService.GetAllVehicles();
            return vehicles;
        }

        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public async Task<Vehicle> Get(int id)
        {
            return await _vehicleService.GetVehicleById(id);
        }

        // POST api/<VehicleController>
        [HttpPost]
        public async Task Post([FromBody] Vehicle vehicle)
        {
            await _vehicleService.AddVehicle(vehicle);
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Vehicle vehicle)
        {
            await _vehicleService.UpdateVehicle(id, vehicle);
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _vehicleService.DeleteVehicle(id);
        }
    }
}
