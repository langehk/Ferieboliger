using Ferieboliger.BLL.Services;
using Ferieboliger.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ferieboliger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitetController : Controller
    {
        private readonly IFacilitetService facilitetService;

        public FacilitetController(IFacilitetService facilitetService)
        {
            this.facilitetService = facilitetService;
        }

        [HttpGet]
        public async Task<ActionResult<Facilitet>> GetFacilities()
        {
            var facilities = await facilitetService.GetFacilitiesAsync();

            if (facilities == null)
            {
                return NotFound();
            }

            return Ok(facilities);
        }
    }
}
