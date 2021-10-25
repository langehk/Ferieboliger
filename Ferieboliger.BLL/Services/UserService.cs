using Ferieboliger.DAL.Context;
using Ferieboliger.DAL.Models;
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
    }
    public class UserService : IUserService
    {
        private readonly FerieboligDbContext dbContext;

        // Dependency injection af DB Context
        public UserService(FerieboligDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
