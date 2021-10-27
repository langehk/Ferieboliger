using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ferieboliger.BLL.Services;
using Ferieboliger.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ferieboliger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FerieboligController : Controller
    {
        private readonly IFerieboligService ferieboligService;

        public FerieboligController(IFerieboligService ferieboligService)
        {
            this.ferieboligService = ferieboligService;
        }

        //Api/Feriebolig
        [HttpGet]
        public async Task<ActionResult<List<Feriebolig>>> GetFerieboliger()
        {
            var ferieboliger = await ferieboligService.GetFerieboligerAsync(); 
            if(ferieboliger == null)
            {
                return NoContent();
            }

            return Ok(ferieboliger); 
        }
    }

    
}
