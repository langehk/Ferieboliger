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
    public interface IFacilitetService
    {
        Task<List<Facilitet>> GetFacilitiesAsync();

    }
    public class FacilitetService : IFacilitetService
    {
        private readonly IDbContextFactory<FerieboligDbContext> _contextFactory;

        public FacilitetService(IDbContextFactory<FerieboligDbContext> contextFactory)
        {
            this._contextFactory = contextFactory;
        }

        public async Task<List<Facilitet>> GetFacilitiesAsync()
        {
            try
            {
                using (var dbContext = _contextFactory.CreateDbContext())
                {
                    return await dbContext.Faciliteter.ToListAsync();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
