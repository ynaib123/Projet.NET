using System.ComponentModel.DataAnnotations;

namespace HotelReservationBackend.Models
{
    public class Employe
    {
        [Key]
        public int Id { get; set; }               // Identifiant unique de l'employé
        
        [Required, MaxLength(50)]
        public string Nom { get; set; }=string.Empty;           // Nom de l'employé
        
        [Required, MaxLength(50)]
        public string Role { get; set; }=string.Empty;          // Rôle de l'employé (par exemple : Réceptionniste, Femme de chambre)
    }
}
