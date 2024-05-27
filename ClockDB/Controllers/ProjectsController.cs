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
    public class ProjectsController : ControllerBase
    {
        private readonly ClockDBContext _context;

        public ProjectsController(ClockDBContext context)
        {
            _context = context;
        }

        


    }
}
