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

    public interface IUserService
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
    }
    public class UserService : IUserService
    {
        private readonly FerieboligDbContext dbContext;

        // Dependency injection af DB Context
        public UserService(FerieboligDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /*
         * Method to get all users. TODO - create Viewmodel to only include certain information from the user
         */
        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                return await dbContext.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<User> GetUserByIdAsync(int id)
        {
            try
            {
                return await dbContext.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
