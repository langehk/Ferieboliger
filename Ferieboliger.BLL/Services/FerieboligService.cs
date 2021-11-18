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
        Task ConvertStringAndUpdateFeriebolig(int id, string content, string property);
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
                return await dbContext.Ferieboliger.Where(x => x.Id == id)
                                                    .Include(x => x.Faciliteter)
                                                    .Include(x => x.Filer)
                                                    .Include(c => c.Bookinger).ThenInclude(c => c.Leveringsadresse)
                                                    .Include(c => c.Adresse)
                                                    .Include(c => c.Spaerringer)
                                                    .FirstOrDefaultAsync();

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
                return await dbContext.Ferieboliger.Include(x => x.Faciliteter).Include(c => c.Adresse).Include(x => x.Filer).Include(x => x.Bookinger).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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

        public async Task ConvertStringAndUpdateFeriebolig(int id, string content, string property)
        {
            try
            {
                Feriebolig feriebolig = await dbContext.Ferieboliger.Where(x => x.Id == id).FirstOrDefaultAsync();
                if(property == "Beskrivelse")
                {
                    feriebolig.Beskrivelse = Encoding.UTF8.GetBytes(content);
                }
                else
                {
                    feriebolig.Bemaerkninger = Encoding.UTF8.GetBytes(content);
                }
                
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
