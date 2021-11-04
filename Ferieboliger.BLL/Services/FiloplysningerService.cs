using Ferieboliger.DAL.Context;
using Ferieboliger.DAL.Models;
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
        //Task UploadImagesAsync(ICollection<Filoplysning> filoplysning, Feriebolig feriebolig);
    }
    public class FiloplysningerService : IFiloplysningerService
    {
        private readonly FerieboligDbContext dbContext;

        public FiloplysningerService(FerieboligDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //public async Task UploadImagesAsync(ICollection<Filoplysning> filoplysning, Feriebolig feriebolig)
        //{

        //    using (var memoryStream = new MemoryStream())
        //    {
        //        await FileUpload.FormFile.CopyToAsync(memoryStream);

        //        var filoplysninger = new Filoplysning()
        //        {
        //            Feriebolig = feriebolig,
        //            FerieboligId = feriebolig.Id,
        //            Name = "test" + DateTime.Now.ToString(),
        //            Data = memoryStream.ToArray()
        //        };

        //        await dbContext.Filoplysninger.AddAsync(filoplysninger);
        //        await dbContext.SaveChangesAsync();

        //    }
        //}
    }
}
