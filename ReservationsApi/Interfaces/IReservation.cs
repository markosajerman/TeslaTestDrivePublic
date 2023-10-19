using ReservationsApi.Models;

namespace ReservationsApi.Interfaces
{
    // Interface used for service methods
    public interface IReservation
    {
        // Method for returning list of Reservations
        Task<List<Reservation>> GetReservations();
        // Method for sending confirmation email to customers who have booked test drive 
        Task UpdateMailStatus(int id);
    }
}
