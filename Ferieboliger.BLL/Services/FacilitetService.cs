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
        private readonly FerieboligDbContext dbContext;

        public FacilitetService(FerieboligDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Facilitet>> GetFacilitiesAsync()
        {
            try
            {
                return await dbContext.Faciliteter.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
