using GolfboxMeeting.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfboxMeeting.BLL
{

    public interface IBookingService
    {
        Task<Booking> CreateBookingAsync(Booking booking);
        Task<List<Booking>> GetExistingBookingsByCourseAndDate(int courseId, DateTime firstTimeOfDay, DateTime lastTimeOfDay);
    }

    public class BookingService : IBookingService
    {
        private readonly DbContext dbContext;
        private const int MAX_NUMBER_OF_PLAYING_PARTNERS = 4;
        
        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            try
            {
                if (booking == null)
                {
                    throw new Exception($"Booking with id: {booking.Id} wasn't created correctly.");
                }

                // Henter eksisterende bookings
                var existingUserBookings = await GetExistingBookingsByUserIdAsync();

                // Check om denne tid er booket i forvejen (Skal naturligvis allerede vises i UI, over ledige tider.)
                // Checker også om der findes en eksisterende tid på brugeren 5 timer frem.
                if (existingUserBookings.Any(x => x.StartTime == booking.StartTime) && existingUserBookings.Any(x => x.StartTime <= DateTime.Now.AddHours(5)))
                {
                    throw new ArgumentException($"You must wait creating another booking"); // Skal sende fejl retur til UI, om at tiden allerede er booket.
                }

                // Check om antallet af medspillere overstiger max.
                if (booking.PlayingPartners.Count <= MAX_NUMBER_OF_PLAYING_PARTNERS)
                {
                    throw new ArgumentException("Too many players added to the booking");
                }


                await dbContext.Booking.AddAsync(booking);
                await dbContext.SaveChangesAsync();

                return booking;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("Error when creating booking");
            }
        }


        public async Task<List<Booking>> GetExistingBookingsByUserIdAsync()
        {

            List<Booking> mockBookings = new List<Booking>() { new Booking() { CourseId = 1, PlayerId = 1, StartTime = DateTime.Now.AddDays(2) } };

            return mockBookings;
        }

        // Hente eksisterende bookinger ud fra en given bane & dato.
        public async Task<List<Booking>> GetExistingBookingsByCourseAndDate(int courseId, DateTime firstTimeOfDay, DateTime lastTimeOfDay)
        {
            try
            {
                // Henter alle bookings i tidsrummet på en given dag, ud fra banens ID.
                var data = await dbContext.Booking.Where(x => x.StartTime >= firstTimeOfDay
                                                        && x.StartTime <= lastTimeOfDay
                                                        && x.CourseId == courseId)
                                                        .ToListAsync();
                return data;

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
