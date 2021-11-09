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
        private readonly FerieboligDbContext dbContext;

        public FiloplysningerService(FerieboligDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        
        public async Task<bool> UploadFile(Filoplysning filoplysning)
        {
            await dbContext.Filoplysninger.AddAsync(filoplysning);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<Filoplysning>> DisplayImagesByIdAsync(int id)
        {
            return await dbContext.Filoplysninger.Where(x => x.FerieboligId == id).ToListAsync();
        }

        public async Task<Filoplysning> DeleteImageByIdAsync(int id)
        {
            try
            {
                var img = await dbContext.Filoplysninger.Where(x => x.Id == id && x.Type == DAL.Models.Enums.FiloplysningType.Image).FirstOrDefaultAsync();
                dbContext.Remove(img);
                await dbContext.SaveChangesAsync();
                return img;
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
                var pdf = await dbContext.Filoplysninger.Where(x => x.Id == id && x.Type == DAL.Models.Enums.FiloplysningType.Document).FirstOrDefaultAsync();
                dbContext.Remove(pdf);
                await dbContext.SaveChangesAsync();
                return pdf;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
