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
        private readonly IDbContextFactory<FerieboligDbContext> _contextFactory;
        private readonly List<int> HoejsaesonUger = new List<int>() {7,28,29,30,31,32,42,51,52};

        public BookingService(IDbContextFactory<FerieboligDbContext> contextFactory)
        {
            this._contextFactory = contextFactory;
        }


        // Get all bookings 
        public async Task<List<Booking>> GetBookingsAsync()
        {
            try
            {
                using (var dbContext = _contextFactory.CreateDbContext())
                {
                    return await dbContext.Bookinger.Where(x => x.Godkendt == true).Include(c => c.Feriebolig).ThenInclude(x => x.Adresse).Include(c => c.Bruger).ToListAsync();
                }
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
                using (var dbContext = _contextFactory.CreateDbContext())
                {
                    return await dbContext.Bookinger.Where(x => x.StartDato >= DateTime.Now && x.Godkendt == true)
                                                    .Include(c => c.Feriebolig).ThenInclude(x => x.Adresse)
                                                    .Include(c => c.Bruger)
                                                    .ToListAsync();
                }
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
                using (var dbContext = _contextFactory.CreateDbContext())
                {
                    return await dbContext.Bookinger.Where(x => x.StartDato <= DateTime.Now && x.Godkendt == true)
                                                    .Include(c => c.Feriebolig).ThenInclude(x => x.Adresse)
                                                    .Include(c => c.Bruger)
                                                    .ToListAsync();
                }
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
                using (var dbContext = _contextFactory.CreateDbContext())
                {
                    return await dbContext.Bookinger.Where(x => x.Id == id && x.Godkendt == true)
                    .Include(x => x.Bruger)
                    .Include(x => x.Leveringsadresse)
                    .Include(x => x.Feriebolig).ThenInclude(x => x.Adresse)
                    .FirstOrDefaultAsync();
                }
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
                using (var dbContext = _contextFactory.CreateDbContext())
                {
                    return await dbContext.Bookinger.Where(x => x.FerieboligId == ferieboligId && x.Godkendt == true).ToListAsync();
                }
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
                using (var dbContext = _contextFactory.CreateDbContext())
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
                using (var dbContext = _contextFactory.CreateDbContext())
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
                using (var dbContext = _contextFactory.CreateDbContext())
                {
                    await dbContext.SaveChangesAsync();
                }
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