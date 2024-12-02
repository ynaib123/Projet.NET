using Microsoft.AspNetCore.Mvc;
using HotelReservationBackend.Services;
using HotelReservationBackend.Models;

namespace HotelReservationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeController : ControllerBase
    {
        private readonly EmployeService _employeService;

        public EmployeController(EmployeService employeService)
        {
            _employeService = employeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employe>>> GetAllEmployes()
        {
            var employes = await _employeService.GetAllEmployesAsync();
            return Ok(employes);
        }

        [HttpPost]
        public async Task<ActionResult> CreateEmploye(Employe employe)
        {
            await _employeService.CreateEmployeAsync(employe);
            return CreatedAtAction(nameof(GetAllEmployes), new { id = employe.Id }, employe);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employe>> GetEmployeById(int id)
        {
            var employe = await _employeService.GetEmployeByIdAsync(id);
            if (employe == null)
            {
                return NotFound();
            }
            return Ok(employe);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmploye(int id, Employe employe)
        {
            if (id != employe.Id)
            {
                return BadRequest();
            }

            await _employeService.UpdateEmployeAsync(employe);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmploye(int id)
        {
            await _employeService.DeleteEmployeAsync(id);
            return NoContent();
        }
    }
}
