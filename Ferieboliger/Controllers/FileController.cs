using Ferieboliger.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Ferieboliger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        private readonly FerieboligDbContext dbContext;

        public FileController(FerieboligDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public async Task<FileStreamResult> DownloadPdfFileById(int id)
        {
            var _fileUpload = dbContext.Filoplysninger.SingleOrDefault(x => x.Id == id);
            MemoryStream ms = new MemoryStream(_fileUpload.Data);
            return new FileStreamResult(ms, "application/pdf");
        }
    }
}
