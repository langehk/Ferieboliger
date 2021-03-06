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

    public interface IBrugerService
    {
        Task<List<Bruger>> GetUsersAsync();
        Task<Bruger> GetUserByIdAsync(int id);
        Task<Bruger> GetUserByEmailAsync(string email);
    }
    public class BrugerService : IBrugerService
    {
        private readonly FerieboligDbContext dbContext;

        // Dependency injection af DB Context
        public BrugerService(FerieboligDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /*
         * Method to get all users. TODO - create Viewmodel to only include certain information from the user
         */
        public async Task<List<Bruger>> GetUsersAsync()
        {
            try
            {
                return await dbContext.Brugere.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<Bruger> GetUserByIdAsync(int id)
        {
            try
            {
                return await dbContext.Brugere.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Bruger> GetUserByEmailAsync(string email)
        {
            try
            {
                return await dbContext.Brugere.Where(x => x.Email == email).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
