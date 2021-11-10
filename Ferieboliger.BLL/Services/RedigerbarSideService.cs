﻿using Ferieboliger.DAL.Context;
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
            try
            {
                var data = await dbContext.RedigerbarSider.Where(x => x.Type == type).FirstOrDefaultAsync();

                if (data == null)
                {
                    throw new Exception();
                }

                // Convert fra byte[] til string
                var base64 = Encoding.ASCII.GetString(data.Content);

                return base64;
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
                var side = await dbContext.RedigerbarSider.Where(x => x.Type == type).FirstOrDefaultAsync();

                //Konverterer streng til bytearray
                byte[] bytes = Encoding.ASCII.GetBytes(data);

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