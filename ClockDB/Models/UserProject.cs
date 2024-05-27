    namespace ClockDB.Models
{   
    public class UserProject
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int project_id {  get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateEnded { get; set; }
    }
}
