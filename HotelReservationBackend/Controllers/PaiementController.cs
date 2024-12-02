using Microsoft.AspNetCore.Mvc;
using HotelReservationBackend.Services;
using HotelReservationBackend.Models;

namespace HotelReservationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaiementController : ControllerBase
    {
        private readonly PaiementService _paiementService;

        public PaiementController(PaiementService paiementService)
        {
            _paiementService = paiementService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Paiement>>> GetAllPaiements()
        {
            var paiements = await _paiementService.GetAllPaiementsAsync();
            return Ok(paiements);
        }

        [HttpPost]
        public async Task<ActionResult> CreatePaiement(Paiement paiement)
        {
            await _paiementService.CreatePaiementAsync(paiement);
            return CreatedAtAction(nameof(GetAllPaiements), new { id = paiement.Id }, paiement);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paiement>> GetPaiementById(int id)
        {
            var paiement = await _paiementService.GetPaiementByIdAsync(id);
            if (paiement == null)
            {
                return NotFound();
            }
            return Ok(paiement);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdatePaiement(int id, Paiement paiement)
        {
            if (id != paiement.Id)
            {
                return BadRequest();
            }

            await _paiementService.UpdatePaiementAsync(paiement);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePaiement(int id)
        {
            await _paiementService.DeletePaiementAsync(id);
            return NoContent();
        }
    }
}
