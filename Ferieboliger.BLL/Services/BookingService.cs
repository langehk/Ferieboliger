using Ferieboliger.DAL.Context;
using Ferieboliger.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
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
        Task<double> CalculateBookingPrice(DateTime? start, DateTime? slut, Feriebolig feriebolig);
    }
    public class BookingService : IBookingService
    {
        private readonly FerieboligDbContext dbContext;
        private readonly List<int> HoejsaesonUger = new List<int>() {7,28,29,30,31,32,42,51,52};

        public BookingService(FerieboligDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        // Get all bookings 
        public async Task<List<Booking>> GetBookingsAsync()
        {
            int attempts = 0;
            int maxAttemps = 5;
            List<Booking> Bookinger = new List<Booking>();

            while (attempts < maxAttemps)
            {
                try
                {
                    Bookinger = await dbContext.Bookinger.Where(x => x.Godkendt == true).Include(c => c.Feriebolig).ThenInclude(x => x.Adresse).Include(c => c.Bruger).ToListAsync();
                    break;
                }
                catch (Exception ex)
                {
                    if (attempts == maxAttemps)
                    {
                        throw new Exception(ex.Message);
                    }
                    await Task.Delay(1000);

                }
                attempts++;
            }
            return Bookinger;
        }

        public async Task<List<Booking>> GetFutureBookingsAsync()
        {
            int attempts = 0;
            int maxAttemps = 5;
            List<Booking> Bookinger = new List<Booking>();

            while(attempts < maxAttemps) { 
                try
                {
                    Bookinger = await dbContext.Bookinger.Where(x => x.StartDato >= DateTime.Now && x.Godkendt == true).Include(c => c.Feriebolig).ThenInclude(x => x.Adresse).Include(c => c.Bruger).ToListAsync();
                    break; 
                }
                catch (Exception ex)
                {
                        if(attempts == maxAttemps)
                        {
                            throw new Exception(ex.Message);
                        }
                    await Task.Delay(1000);
                
                }
                attempts++; 
            }
            return Bookinger;
        }

        public async Task<List<Booking>> GetPreviousBookingsAsync()
        {
            int attempts = 0;
            int maxAttemps = 5;
            List<Booking> Bookinger = new List<Booking>();

            while (attempts < maxAttemps)
            {
                try
                {
                    Bookinger = await dbContext.Bookinger.Where(x => x.StartDato <= DateTime.Now && x.Godkendt == true).Include(c => c.Feriebolig).ThenInclude(x => x.Adresse).Include(c => c.Bruger).ToListAsync();
                    break;
                }
                catch (Exception ex)
                {
                    if (attempts == maxAttemps)
                    {
                        throw new Exception(ex.Message);
                    }
                    await Task.Delay(1000);

                }
                attempts++;
            }
            return Bookinger;
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
                return await dbContext.Bookinger.Where(x => x.FerieboligId == ferieboligId && x.Godkendt == true).ToListAsync();
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

        public async Task<Booking> DeleteBookingByIdAsync(int id)
        {
            try
            {
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


        public async Task<double> CalculateBookingPrice(DateTime? start, DateTime? slut, Feriebolig feriebolig)
        {
            double dagsPrisHoej = (double)feriebolig.PrisHoejUge / 7;
            double dagsPrisLav = (double)feriebolig.PrisLavUge / 7;
            
            double totalPris = 0;

            CultureInfo inf = new CultureInfo("da-DK");
            Calendar myCal = inf.Calendar;
            CalendarWeekRule myCWR = inf.DateTimeFormat.CalendarWeekRule;
            DayOfWeek myFirstDOW = inf.DateTimeFormat.FirstDayOfWeek;

            // Speciel pris hvis man booker fre til søn
            if (start.Value.DayOfWeek == DayOfWeek.Friday && slut.Value == start.Value.AddDays(2))
            {
                if (HoejsaesonUger.Contains(myCal.GetWeekOfYear(start.Value, myCWR, myFirstDOW)))
                {
                    totalPris = feriebolig.PrisHoejWeekend;
                }
                else
                {
                    totalPris = feriebolig.PrisLavWeekend;
                }

                return totalPris;
            }

            while (start < slut)
            {
                if (HoejsaesonUger.Contains(myCal.GetWeekOfYear(start.Value, myCWR, myFirstDOW)))
                {
                    totalPris += dagsPrisHoej;
                }
                else
                {
                    totalPris += dagsPrisLav;
                }

                start = start.Value.AddDays(1);
            }

            return Math.Ceiling(totalPris);
        }
    }
}


