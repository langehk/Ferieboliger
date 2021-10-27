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
    public class BrugerController : Controller
    {
        private readonly IBrugerService userService;

        public BrugerController(IBrugerService userService)
        {
            this.userService = userService;
        }

        // api/user 
        [HttpGet]
        public async Task<ActionResult<List<Bruger>>> GetUsers()
        {
            var users =  await userService.GetUsersAsync();

            if (users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        // api/user/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Bruger>> GetUserById(int id)
        {
            var user = await userService.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
