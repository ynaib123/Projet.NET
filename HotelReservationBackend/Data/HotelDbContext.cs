using HotelReservationBackend.Models;
using Microsoft.EntityFrameworkCore;
namespace HotelReservationBackend.Data{
public class HotelDbContext : DbContext
{
    public HotelDbContext(DbContextOptions<HotelDbContext> options)
        : base(options)
    {
    }

    public DbSet<Client> Clients { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Chambre> Chambres { get; set; }
    public DbSet<Admin> Admins { get; set; }
    public DbSet<Paiement> Payments { get; set; }
    public DbSet<Employe> Employes {get; set;}

}
}