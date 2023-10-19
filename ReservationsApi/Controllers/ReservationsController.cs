using Microsoft.AspNetCore.Mvc;
using ReservationsApi.Interfaces;
using ReservationsApi.Models;
using System.Runtime.CompilerServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ReservationsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        // _reservationService field of a type IReservation
        private IReservation _reservationService;
        // Injecting IReservation interface inside of a constructor
        public ReservationsController(IReservation reservationService)
        {
            _reservationService = reservationService;
        }
        // GET: api/<ReservationsController>
        // Controller for returning a list of Reservations
        [HttpGet]
        public async Task<IEnumerable<Reservation>> Get()
        {
            var reservations = await _reservationService.GetReservations();
            return reservations;
        }

        // PUT api/<ReservationsController>/5
        // Controller for updating a mail status
        [HttpPut("{id}")]
        public async Task Put(int id)
        {
            await _reservationService.UpdateMailStatus(id);
        }

    }
}
