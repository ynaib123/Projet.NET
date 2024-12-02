using Microsoft.EntityFrameworkCore;
using HotelReservationBackend.Models;
using HotelReservationBackend.Data;

namespace HotelReservationBackend.Services
{
    public class ReservationService
    {
        private readonly HotelDbContext _context;

        public ReservationService(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<List<Reservation>> GetAllReservationsAsync()
        {
            return await _context.Reservations.Include(r => r.Client).Include(r => r.Chambre).ToListAsync();
        }

        public async Task CreateReservationAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task<Reservation?> GetReservationByIdAsync(int id)
        {
            return await _context.Reservations.Include(r => r.Client).Include(r => r.Chambre)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task UpdateReservationAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReservationAsync(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
