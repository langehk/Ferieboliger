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
    public interface IAdresseService
    {
        Task<Adresse> CreateAddressAsync(Adresse adresse);
    }
    public class AdresseService : IAdresseService
    {
        private readonly IDbContextFactory<FerieboligDbContext> _contextFactory;

        public AdresseService(IDbContextFactory<FerieboligDbContext> contextFactory)
        {
            this._contextFactory = contextFactory;
        }

        public async Task<Adresse> CreateAddressAsync(Adresse adresse)
        {
            try
            {
                using (var dbContext = _contextFactory.CreateDbContext())
                {
                    await dbContext.Adresser.AddAsync(adresse);
                    await dbContext.SaveChangesAsync();
                }

                return adresse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
