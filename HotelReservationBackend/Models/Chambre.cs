using System.ComponentModel.DataAnnotations;

namespace HotelReservationBackend.Models
{
    public class Chambre
    {
        [Key]
        public int Id { get; set; }                // Identifiant de la chambre
        
        [Required]
        public string NumChambre { get; set; }=string.Empty;     // Numéro de la chambre
        
        [Required, Range(0, double.MaxValue)]
        public decimal PrixParJour { get; set; }   // Prix par nuit
        
        public bool EstDisponible { get; set; }    // Indique si la chambre est disponible
        
        [Required, MaxLength(20)]
        public string TypeChambre { get; set; }=string.Empty;    // individuelle/double/famille/suite
    }
}
