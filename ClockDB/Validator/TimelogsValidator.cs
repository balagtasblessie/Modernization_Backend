using ClockDB.Models;

namespace ClockDB.Validator
{
    public class TimelogsValidator
    {
        public TimelogsValidator() {

        }
        public bool ValidateTimeLogs(TimeLogs timeLogs)
        {

            return timeLogs.ClockOut >= timeLogs.ClockIn;
        }

        public bool ValidateTimeLog(TimeLogs timeLogs)
        {
           
            return timeLogs != null;
        }


    }
}
