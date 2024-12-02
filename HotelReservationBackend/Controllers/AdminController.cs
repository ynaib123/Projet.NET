using Microsoft.AspNetCore.Mvc;
using HotelReservationBackend.Services;
using HotelReservationBackend.Models;

namespace HotelReservationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Admin>>> GetAllAdmins()
        {
            var admins = await _adminService.GetAllAdminsAsync();
            return Ok(admins);
        }

        [HttpPost]
        public async Task<ActionResult> CreateAdmin(Admin admin)
        {
            await _adminService.CreateAdminAsync(admin);
            return CreatedAtAction(nameof(GetAllAdmins), new { id = admin.Id }, admin);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdminById(int id)
        {
            var admin = await _adminService.GetAdminByIdAsync(id);
            if (admin == null)
            {
                return NotFound();
            }
            return Ok(admin);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAdmin(int id, Admin admin)
        {
            if (id != admin.Id)
            {
                return BadRequest();
            }

            await _adminService.UpdateAdminAsync(admin);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAdmin(int id)
        {
            await _adminService.DeleteAdminAsync(id);
            return NoContent();
        }
    }
}
