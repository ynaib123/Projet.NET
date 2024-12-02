using Microsoft.EntityFrameworkCore;
using HotelReservationBackend.Models;
using HotelReservationBackend.Data;

namespace HotelReservationBackend.Services
{
    public class PaiementService
    {
        private readonly HotelDbContext _context;

        public PaiementService(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<List<Paiement>> GetAllPaiementsAsync()
        {
            return await _context.Payments.Include(p => p.Reservation).ToListAsync();
        }

        public async Task CreatePaiementAsync(Paiement paiement)
        {
            _context.Payments.Add(paiement);
            await _context.SaveChangesAsync();
        }

        public async Task<Paiement?> GetPaiementByIdAsync(int id)
        {
            return await _context.Payments.Include(p => p.Reservation)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdatePaiementAsync(Paiement paiement)
        {
            _context.Payments.Update(paiement);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePaiementAsync(int id)
        {
            var paiement = await _context.Payments.FindAsync(id);
            if (paiement != null)
            {
                _context.Payments.Remove(paiement);
                await _context.SaveChangesAsync();
            }
        }
    }
}
