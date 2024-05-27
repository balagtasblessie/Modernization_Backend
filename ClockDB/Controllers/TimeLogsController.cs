using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClockDB.Data;
using ClockDB.Models;
using ClockDB.Manager;

namespace ClockDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeLogsController : ControllerBase
    {
        private readonly ClockDBContext _context;
        private readonly TimelogsManager _timelogsManager;

        public TimeLogsController(ClockDBContext context)
        {
            _context = context;
            _timelogsManager = new TimelogsManager(context);
        }

        [HttpGet("mytimelogs")]
        public async Task<ActionResult<IEnumerable<TimeLogs>>> GetTimeLogs(int userid)
        {
            try
            {
                var timeLogs = await _timelogsManager.GetDailyTimeLogsAsync(userid);
                return Ok(timeLogs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("dailytimelogs")]
        public async Task<ActionResult<IEnumerable<TimeLogs>>> GetDailyTimeLogs(int userid)
        {
            try
            {
                var today = DateTime.Today;
                var timeLogs = await _context.TimeLogs
                    .Where(t => t.Userid == userid && t.ClockIn.Date == today)
                    .ToListAsync();
                return Ok(timeLogs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpPost("timelogs")]
        public async Task<ActionResult<TimeLogs>> PostTimeLog([FromBody] TimeLogs timeLogs, bool isClockedIn)
        {
            var currentTime = DateTime.Now;

            try
            {
                if (isClockedIn)
                {
                    timeLogs.ClockIn = currentTime;
                    timeLogs.ClockOut = null;
                    _context.TimeLogs.Add(timeLogs);
                }
                else
                {
                    var existingLog = await _context.TimeLogs
                        .Where(t => t.Userid == timeLogs.Userid && t.ClockIn.Date == currentTime.Date && t.ClockOut == null)
                        .FirstOrDefaultAsync();

                    if (existingLog != null)
                    {
                        existingLog.ClockOut = currentTime;
                        _context.Entry(existingLog).State = EntityState.Modified;
                    }
                    else
                    {
                        return BadRequest("Clock-in entry not found for today.");
                    }
                }

                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetTimeLogs), new { userId = timeLogs.Userid }, timeLogs);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
