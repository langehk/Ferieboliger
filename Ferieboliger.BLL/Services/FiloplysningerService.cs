using Ferieboliger.DAL.Context;
using Ferieboliger.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferieboliger.BLL.Services
{


    public interface IFiloplysningerService
    {
        Task<bool> UploadFile(Filoplysning filoplysning);
        Task<List<Filoplysning>> DisplayImagesByIdAsync(int id);
        Task<Filoplysning> DeleteImageByIdAsync(int id);
        Task<Filoplysning> DeletePdfDocumentByIdAsync(int id);
    }
    public class FiloplysningerService : IFiloplysningerService
    {
        private readonly IDbContextFactory<FerieboligDbContext> _contextFactory;

        public FiloplysningerService(IDbContextFactory<FerieboligDbContext> contextFactory)
        {
            this._contextFactory = contextFactory;
        }

        
        public async Task<bool> UploadFile(Filoplysning filoplysning)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                await dbContext.Filoplysninger.AddAsync(filoplysning);
                await dbContext.SaveChangesAsync();
            }

            return true;
        }

        public async Task<List<Filoplysning>> DisplayImagesByIdAsync(int id)
        {
            using (var dbContext = _contextFactory.CreateDbContext())
            {
                return await dbContext.Filoplysninger.Where(x => x.FerieboligId == id).ToListAsync();
            }
        }

        public async Task<Filoplysning> DeleteImageByIdAsync(int id)
        {
            try
            {
                using (var dbContext = _contextFactory.CreateDbContext())
                {
                    var img = await dbContext.Filoplysninger.Where(x => x.Id == id && x.Type == DAL.Models.Enums.FiloplysningType.Image).FirstOrDefaultAsync();
                    dbContext.Remove(img);
                    await dbContext.SaveChangesAsync();
                    return img;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Filoplysning> DeletePdfDocumentByIdAsync(int id)
        {
            try
            {
                using (var dbContext = _contextFactory.CreateDbContext())
                {
                    var pdf = await dbContext.Filoplysninger.Where(x => x.Id == id && x.Type == DAL.Models.Enums.FiloplysningType.Document).FirstOrDefaultAsync();
                    dbContext.Remove(pdf);
                    await dbContext.SaveChangesAsync();
                    return pdf;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
