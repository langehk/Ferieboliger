using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferieboliger.DAL.Context;
using Ferieboliger.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Ferieboliger.BLL.Services
{
    public interface IFerieboligService
    {
        Task<List<Feriebolig>> GetFerieboligerAsync();
        Task<Feriebolig> GetFerieboligByIdAsync(int id);
        Task<Feriebolig> AddFerieboligAsync(Feriebolig feriebolig);
        Task UpdateFeriebolig();
        void ResetContextState();

    }
    public class FerieboligService : IFerieboligService
    {
        private readonly FerieboligDbContext dbContext;
        private readonly IAdresseService adresseService;

        public FerieboligService(FerieboligDbContext dbContext, IAdresseService adresseService)
        {
            this.dbContext = dbContext;
            this.adresseService = adresseService;
        }

        public async Task<Feriebolig> AddFerieboligAsync(Feriebolig feriebolig)
        {
            try
            {
                await dbContext.Ferieboliger.AddAsync(feriebolig);
                await dbContext.SaveChangesAsync();
                return feriebolig;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Feriebolig> GetFerieboligByIdAsync(int id)
        {
            try
            {
                return await dbContext.Ferieboliger.Where(x => x.Id == id).Include(x => x.Faciliteter).Include(c => c.Bookinger).Include(c => c.Adresse).FirstOrDefaultAsync();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Feriebolig>> GetFerieboligerAsync()
        {
            try
            {
                return await dbContext.Ferieboliger.Include(x => x.Faciliteter).Include(c => c.Adresse).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //TODO skal den tage et objekt ind eller hvordan vil vi bruge den?
        public async Task UpdateFeriebolig()
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

        public void ResetContextState()
        {
            dbContext.ChangeTracker.Entries()
            .Where(e => e.Entity != null).ToList()
            .ForEach(e => e.State = EntityState.Unchanged);
        }

    }
}
