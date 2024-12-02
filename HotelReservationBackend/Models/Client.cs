using System.ComponentModel.DataAnnotations;

namespace HotelReservationBackend.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }           // Identifiant du client
        
        [Required, MaxLength(50)]
        public string Nom { get; set; }=string.Empty;       // Nom du client
        
        [Required, MaxLength(50)]
        public string Prenom { get; set; }=string.Empty;    // Prénom du client
        
        [Required, EmailAddress]
        public string Email { get; set; }=string.Empty;     // Email du client
    }
}
