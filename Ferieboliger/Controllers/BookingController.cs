using Ferieboliger.BLL.Services;
using Ferieboliger.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferieboliger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : Controller
    {

        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        // Api/Booking
        [HttpGet]
        public async Task<ActionResult<List<Booking>>> GetBookings()
        {
            var bookings = await bookingService.GetBookingsAsync();

            if (bookings == null)
            {
                // TODO - Better handling, if we don't retrieve at user
                return NotFound();
            }

            return Ok(bookings);
        }

        // Api/Booking/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBookingById(int id)
        {
            var booking = await bookingService.GetBookingByIdAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return booking;
        }

    }
}
