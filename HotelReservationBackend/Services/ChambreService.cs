using Microsoft.EntityFrameworkCore;
using HotelReservationBackend.Models;
using HotelReservationBackend.Data;

namespace HotelReservationBackend.Services
{
    public class ChambreService
    {
        private readonly HotelDbContext _context;

        public ChambreService(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<List<Chambre>> GetAllChambresAsync()
        {
            return await _context.Chambres.ToListAsync();
        }

        public async Task CreateChambreAsync(Chambre chambre)
        {
            _context.Chambres.Add(chambre);
            await _context.SaveChangesAsync();
        }

        public async Task<Chambre?> GetChambreByIdAsync(int id)
        {
            return await _context.Chambres.FindAsync(id);
        }

        public async Task UpdateChambreAsync(Chambre chambre)
        {
            _context.Chambres.Update(chambre);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteChambreAsync(int id)
        {
            var chambre = await _context.Chambres.FindAsync(id);
            if (chambre != null)
            {
                _context.Chambres.Remove(chambre);
                await _context.SaveChangesAsync();
            }
        }
    }
}
