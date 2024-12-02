using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationBackend.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }                  // Identifiant de la réservation
        
        [Required, ForeignKey("Client")]
        public int IdClient { get; set; }           // Identifiant du client
        
        [Required, ForeignKey("Chambre")]
        public int IdChambre { get; set; }          // Identifiant de la chambre
        
        [Required]
        public DateTime DateDebut { get; set; }     // Date de début de la réservation
        
        [Required]
        public DateTime DateFin { get; set; }       // Date de fin de la réservation

        // Navigation properties
        public Client? Client { get; set; }
        public Chambre? Chambre { get; set; }
    }
}
