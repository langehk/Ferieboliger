using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ferieboliger.DAL.Models;
using Ferieboliger.DAL.Context;

namespace Ferieboliger.BLL.Services
{
    public interface ISpaerringService
    {
        Task<Spaerring> CreateSpaerringAsync(Spaerring spaerring);
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
    }
}
