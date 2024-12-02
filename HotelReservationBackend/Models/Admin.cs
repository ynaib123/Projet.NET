using System.ComponentModel.DataAnnotations;

namespace HotelReservationBackend.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }                // Identifiant unique de l'admin
        
        [Required, MaxLength(50)]
        public string NomUtilisateur { get; set; }= string.Empty; // Nom d'utilisateur pour la connexion
        
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }=string.Empty;       // Mot de passe de l'admin
    }
}
