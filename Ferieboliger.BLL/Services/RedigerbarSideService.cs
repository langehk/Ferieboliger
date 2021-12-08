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
        private readonly IDbContextFactory<FerieboligDbContext> _contextFactory;

        public RedigerbarSideService(IDbContextFactory<FerieboligDbContext> contextFactory)
        {
            this._contextFactory = contextFactory;
        }


        public async Task<string> GetRedigerbarSideContentByType(RedigerbarSideType type)
        {
            try
            {
                using (var dbContext = _contextFactory.CreateDbContext())
                {
                    var data = await dbContext.RedigerbarSider.Where(x => x.Type == type).FirstOrDefaultAsync();
                
                    if (data == null)
                    {
                        throw new Exception();
                    }

                    if(data.Content != null)
                    {
                        // Convert fra byte[] til string
                    
                        var base64 = Encoding.UTF8.GetString(data.Content);

                        return base64;
                    }

                    return "";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<RedigerbarSide> SaveRedigerbarSideContentById(RedigerbarSideType type, string data)
        {
            try
            {
                using (var dbContext = _contextFactory.CreateDbContext())
                {
                    var side = await dbContext.RedigerbarSider.Where(x => x.Type == type).FirstOrDefaultAsync();

                    //Konverterer streng til bytearray
                    byte[] bytes = Encoding.UTF8.GetBytes(data);

                    side.Content = bytes;

                    await dbContext.SaveChangesAsync();

                    return side;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
