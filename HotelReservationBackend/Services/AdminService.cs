using Microsoft.EntityFrameworkCore;
using HotelReservationBackend.Models;
using HotelReservationBackend.Data;

namespace HotelReservationBackend.Services
{
    public class AdminService
    {
        private readonly HotelDbContext _context;

        public AdminService(HotelDbContext context)
        {
            _context = context;
        }

        public async Task<List<Admin>> GetAllAdminsAsync()
        {
            return await _context.Admins.ToListAsync();
        }

        public async Task CreateAdminAsync(Admin admin)
        {
            _context.Admins.Add(admin);
            await _context.SaveChangesAsync();
        }

        public async Task<Admin?> GetAdminByIdAsync(int id)
        {
            return await _context.Admins.FindAsync(id);
        }

        public async Task UpdateAdminAsync(Admin admin)
        {
            _context.Admins.Update(admin);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAdminAsync(int id)
        {
            var admin = await _context.Admins.FindAsync(id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
                await _context.SaveChangesAsync();
            }
        }
    }
}
