using Ferieboliger.DAL.Context;
using Ferieboliger.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.BLL.Services
{

    public interface IBookingService
    {
        Task<List<Booking>> GetBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int id);
        Task<Booking> DeleteBookingByIdAsync(int id);
        Task<Booking> UpdateBookingAsync(int id, Booking booking);
    }
    public class BookingService : IBookingService
    {
        private readonly FerieboligDbContext dbContext;

        public BookingService(FerieboligDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        // Get all bookings 
        public async Task<List<Booking>> GetBookingsAsync()
        {
            try
            {
                return await dbContext.Bookings.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        // Get specific booking by ID
        public async Task<Booking> GetBookingByIdAsync(int id)
        {
            try
            {
                return await dbContext.Bookings.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        // Create booking
        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            try
            {
                if (booking == null)
                {
                    // TODO - Better errorhandling, shouldn't be displayed in the console.'
                    throw new Exception("Error when creating the booking");
                }

                await dbContext.Bookings.AddAsync(booking);
                await dbContext.SaveChangesAsync();

                return booking;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        // Delete booking  TODO - Add authorization on this
        public async Task<Booking> DeleteBookingByIdAsync(int id)
        {
            try
            {
                var booking = await dbContext.Bookings.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (booking == null)
                {
                    // TODO - Better errorhandling, shouldn't be displayed in the console.
                    Console.WriteLine($"Booking with id {id} not found");
                }

                dbContext.Bookings.Remove(booking);
                await dbContext.SaveChangesAsync();

                return booking;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update booking
        public async Task<Booking> UpdateBookingAsync(int id, Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
