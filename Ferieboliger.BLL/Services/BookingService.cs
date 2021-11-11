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
        Task<List<Booking>> GetFutureBookingsAsync();
        Task<List<Booking>> GetPreviousBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int id);
        Task<Booking> DeleteBookingByIdAsync(int id);
        Task UpdateBookingAsync();
        Task<Booking> CreateBookingAsync(Booking booking);
        Task<List<Booking>> GetBookingsByFerieboligId(int ferieboligId);
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
                return await dbContext.Bookinger.Include(c => c.Feriebolig).ThenInclude(x => x.Adresse).Include(c => c.Bruger).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Booking>> GetFutureBookingsAsync()
        {
            try
            {
                return await dbContext.Bookinger.Where(x => x.UdlejDato >= DateTime.Now).Include(c => c.Feriebolig).ThenInclude(x => x.Adresse).Include(c => c.Bruger).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Booking>> GetPreviousBookingsAsync()
        {
            try
            {
                return await dbContext.Bookinger.Where(x => x.UdlejDato <= DateTime.Now).Include(c => c.Feriebolig).ThenInclude(x => x.Adresse).Include(c => c.Bruger).ToListAsync();
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
                return await dbContext.Bookinger.Where(x => x.Id == id)
                    .Include(x => x.Bruger)
                    .Include(x => x.Leveringsadresse)
                    .Include(x => x.Feriebolig).ThenInclude(x => x.Adresse)
                    .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Get bookings made for specific feriebolig
        public async Task<List<Booking>> GetBookingsByFerieboligId(int ferieboligId)
        {
            try
            {
                return await dbContext.Bookinger.Where(x => x.FerieboligId == ferieboligId).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.ToString());
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

                await dbContext.Bookinger.AddAsync(booking);
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
                //TODO vi skal også slette leveringsadressen!
                var booking = await dbContext.Bookinger.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (booking == null)
                {
                    // TODO - Better errorhandling, shouldn't be displayed in the console.
                    Console.WriteLine($"Booking with id {id} not found");
                }

                dbContext.Bookinger.Remove(booking);
                await dbContext.SaveChangesAsync();

                return booking;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Update booking
        public async Task UpdateBookingAsync()
        {
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
