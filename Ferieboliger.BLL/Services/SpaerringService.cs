using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferieboliger.DAL.Models;
using Ferieboliger.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace Ferieboliger.BLL.Services
{
    public interface ISpaerringService
    {
        Task<Spaerring> CreateSpaerringAsync(Spaerring spaerring);

        Task<Spaerring> DeleteSpaerringByIdAsync(int id);
    }
    public class SpaerringService : ISpaerringService
    {
        private readonly FerieboligDbContext dbContext;
        
        public SpaerringService(FerieboligDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Spaerring> CreateSpaerringAsync(Spaerring spaerring)
        {
            try
            {
                await dbContext.Spaerringer.AddAsync(spaerring);
                await dbContext.SaveChangesAsync();
                return spaerring;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public async Task<Spaerring> DeleteSpaerringByIdAsync(int id)
        {
            try
            {
                var spaerring = await dbContext.Spaerringer.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (spaerring == null)
                {
                    // TODO - Better errorhandling, shouldn't be displayed in the console.
                    Console.WriteLine($"Booking with id {id} not found");
                }

                dbContext.Spaerringer.Remove(spaerring);
                await dbContext.SaveChangesAsync();
                return spaerring;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
