using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationsApi.Models
{
    public class Reservation
    {
        [Key]
        // Prevent autoincrement function of Primary Key, therefore DataBaseGeneratedOption is set o None
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public bool IsMailSent { get; set; }
    }
}
