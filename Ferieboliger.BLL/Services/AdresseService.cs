using Ferieboliger.DAL.Context;
using Ferieboliger.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.BLL.Services
{
    public interface IAdresseService
    {
        Task<Adresse> CreateAddressAsync(Adresse adresse);
    }
    public class AdresseService : IAdresseService
    {
        private readonly FerieboligDbContext dbContext;

        public AdresseService(FerieboligDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Adresse> CreateAddressAsync(Adresse adresse)
        {
            try
            {
                await dbContext.Adresser.AddAsync(adresse);
                await dbContext.SaveChangesAsync();

                return adresse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
