using Microsoft.AspNetCore.Mvc;
using HotelReservationBackend.Services;
using HotelReservationBackend.Models;

namespace HotelReservationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Reservation>>> GetAllReservations()
        {
            var reservations = await _reservationService.GetAllReservationsAsync();
            return Ok(reservations);
        }

        [HttpPost]
        public async Task<ActionResult> CreateReservation(Reservation reservation)
        {
            await _reservationService.CreateReservationAsync(reservation);
            return CreatedAtAction(nameof(GetAllReservations), new { id = reservation.Id }, reservation);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservationById(int id)
        {
            var reservation = await _reservationService.GetReservationByIdAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            return Ok(reservation);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateReservation(int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }

            await _reservationService.UpdateReservationAsync(reservation);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteReservation(int id)
        {
            await _reservationService.DeleteReservationAsync(id);
            return NoContent();
        }
    }
}
