using Microsoft.AspNetCore.Mvc;
using HotelReservationBackend.Services;
using HotelReservationBackend.Models;

namespace HotelReservationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChambreController : ControllerBase
    {
        private readonly ChambreService _chambreService;

        public ChambreController(ChambreService chambreService)
        {
            _chambreService = chambreService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Chambre>>> GetAllChambres()
        {
            var chambres = await _chambreService.GetAllChambresAsync();
            return Ok(chambres);
        }

        [HttpPost]
        public async Task<ActionResult> CreateChambre(Chambre chambre)
        {
            await _chambreService.CreateChambreAsync(chambre);
            return CreatedAtAction(nameof(GetAllChambres), new { id = chambre.Id }, chambre);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Chambre>> GetChambreById(int id)
        {
            var chambre = await _chambreService.GetChambreByIdAsync(id);
            if (chambre == null)
            {
                return NotFound();
            }
            return Ok(chambre);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateChambre(int id, Chambre chambre)
        {
            if (id != chambre.Id)
            {
                return BadRequest();
            }

            await _chambreService.UpdateChambreAsync(chambre);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteChambre(int id)
        {
            await _chambreService.DeleteChambreAsync(id);
            return NoContent();
        }
    }
}
