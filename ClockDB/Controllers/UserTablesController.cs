using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClockDB.Data;
using ClockDB.Models;

namespace ClockDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserTablesController : ControllerBase
    {
        private readonly ClockDBContext _context;

        public UserTablesController(ClockDBContext context)
        {
            _context = context;
        }

        /*// GET: api/UserTables
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserTable userObj)
        {
            if (userObj == null)
                return BadRequest();

            var user = await _context.UserTable
                .FirstOrDefaultAsync(x => x.UserName == userObj.UserName && x.Password == userObj.Password);
            if (user == null)
                return NotFound(new { message = "User Not Found!" });

            return Ok(new 
            {
                Message = "Login Success!"
            });

        }*/

    }
}
