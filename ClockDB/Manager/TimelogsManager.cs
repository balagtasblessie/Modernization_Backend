using ClockDB.Data;
using ClockDB.Models;
using ClockDB.Repository;
using ClockDB.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClockDB.Manager
{
    public class TimelogsManager
    {
        private readonly TimelogsRepository _timelogsRepository;

        public TimelogsManager(ClockDBContext context)
        {
            _timelogsRepository = new TimelogsRepository(context);
        }

        public async Task<IEnumerable<TimeLogs>> GetDailyTimeLogsAsync(int userId)
        {
            var timeLogs = await _timelogsRepository.GetTimeLogsAsync(userId);

            var groupedLogs = timeLogs
                .GroupBy(log => log.ClockIn.Date)
                .Select(g => new TimeLogs
                {
                    Userid = userId,
                    ClockIn = g.Min(log => log.ClockIn),
                    ClockOut = g.Max(log => log.ClockOut)
                });

            return groupedLogs;
        }
    }
}
