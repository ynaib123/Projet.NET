using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationBackend.Models
{
    public class Paiement
    {
        [Key]
        public int Id { get; set; }                     // Identifiant du paiement
        
        [Required, ForeignKey("Reservation")]
        public int IdReservation { get; set; }         // Réservation associée
        
        [Required, Range(0, double.MaxValue)]
        public decimal Montant { get; set; }           // Montant payé
        
        [Required]
        public DateTime DatePaiement { get; set; }     // Date du paiement
        
        [Required, MaxLength(30)]
        public string MethodePaiement { get; set; }=string.Empty;    // Méthode de paiement (Carte bancaire, PayPal, etc.)

        // Navigation property
        public Reservation? Reservation { get; set; }
    }
}
