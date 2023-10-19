using System.ComponentModel.DataAnnotations;

namespace ReservationsApi.Models
{
    public class Vehicle
    {
        // Adding VId as primary key, since Id is obtained from azure service bus
        [Key]
        public int VId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
