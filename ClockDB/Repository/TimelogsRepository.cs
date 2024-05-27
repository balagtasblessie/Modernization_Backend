using ClockDB.Data;
using ClockDB.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClockDB.Repository
{
    public class TimelogsRepository
    {
        private readonly ClockDBContext _context;

        public TimelogsRepository(ClockDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TimeLogs>> GetTimeLogsAsync(int userid)
        {
            return await _context.TimeLogs
                .Where(t => t.Userid == userid)
                .ToListAsync();
        }

        public async Task AddTimeLogAsync(TimeLogs timeLog)
        {
            _context.TimeLogs.Add(timeLog);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTimeLogAsync(TimeLogs timeLog)
        {
            _context.Entry(timeLog).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
