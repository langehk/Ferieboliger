using Ferieboliger.DAL.Context;
using Ferieboliger.DAL.Models;
using Ferieboliger.DAL.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.BLL.Services
{

    public interface IRedigerbarSideService
    {
        Task<string> GetRedigerbarSideContentByType(RedigerbarSideType type);
        Task<RedigerbarSide> SaveRedigerbarSideContentById(RedigerbarSideType type, string data);
    }

    public class RedigerbarSideService : IRedigerbarSideService
    {
        private readonly FerieboligDbContext dbContext;

        public RedigerbarSideService(FerieboligDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<string> GetRedigerbarSideContentByType(RedigerbarSideType type)
        {
            int attempts = 0;
            int maxAttemps = 5;
            var data = ""; 

            while (attempts < maxAttemps)
            {
                try
                {
                    var byteArray = await dbContext.RedigerbarSider.Where(x => x.Type == type).FirstOrDefaultAsync();

                    if (byteArray == null)
                    {
                        data = ""; 
                    }

                    if (byteArray.Content != null)
                    {
                        // Convert fra byte[] til string

                        data = Encoding.UTF8.GetString(byteArray.Content);
                    }
                }
                catch (Exception ex)
                {
                    if (attempts == maxAttemps)
                    {
                        throw new Exception(ex.Message);
                    }
                    await Task.Delay(1000);
                }
                attempts++;
            }
            return data; 
        }


        public async Task<RedigerbarSide> SaveRedigerbarSideContentById(RedigerbarSideType type, string data)
        {
            try
            {
                var side = await dbContext.RedigerbarSider.Where(x => x.Type == type).FirstOrDefaultAsync();

                //Konverterer streng til bytearray
                byte[] bytes = Encoding.UTF8.GetBytes(data);

                side.Content = bytes;

                await dbContext.SaveChangesAsync();

                return side;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
