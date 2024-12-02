using Microsoft.EntityFrameworkCore;
using HotelReservationBackend.Models;
using HotelReservationBackend.Data;

namespace HotelReservationBackend.Services
{
    public class EmployeService
    {
        private readonly HotelDbContext _context;

        public EmployeService(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<List<Employe>> GetAllEmployesAsync()
        {
            return await _context.Employes.ToListAsync();
        }

        public async Task CreateEmployeAsync(Employe employe)
        {
            _context.Employes.Add(employe);
            await _context.SaveChangesAsync();
        }

        public async Task<Employe?> GetEmployeByIdAsync(int id)
        {
            return await _context.Employes.FindAsync(id);
        }

        public async Task UpdateEmployeAsync(Employe employe)
        {
            _context.Employes.Update(employe);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeAsync(int id)
        {
            var employe = await _context.Employes.FindAsync(id);
            if (employe != null)
            {
                _context.Employes.Remove(employe);
                await _context.SaveChangesAsync();
            }
        }
    }
}
