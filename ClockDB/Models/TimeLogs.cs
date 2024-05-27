namespace ClockDB.Models
{
    public class TimeLogs
    {
        public int? TimeLogsId { get; set; }
        public int Userid { get; set; }
        public DateTime ClockIn { get; set; }
        public DateTime? ClockOut { get; set; }
    }
}
