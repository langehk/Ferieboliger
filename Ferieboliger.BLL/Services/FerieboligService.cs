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
        Task<Feriebolig> UpdateFeriebolig(Feriebolig feriebolig);


    }
    public class FerieboligService : IFerieboligService
    {
        private readonly FerieboligDbContext dbContext;

        public FerieboligService(FerieboligDbContext dbContext)
        {
            this.dbContext = dbContext;
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
                return await dbContext.Ferieboliger.Where(x => x.Id == id).Include(x => x.Faciliteter).FirstOrDefaultAsync();

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
                return await dbContext.Ferieboliger.Include(x => x.Faciliteter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //TODO skal den tage et objekt ind eller hvordan vil vi bruge den?
        public async Task<Feriebolig> UpdateFeriebolig(Feriebolig feriebolig)
        {
            try
            {
                await dbContext.SaveChangesAsync();
                return feriebolig;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
