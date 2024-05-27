using System.Security.Claims;

namespace ClockDB.Models
{
    public class User
    {
        public int id {  get; set; }
        public string FullName { get; set; }
        public string roleDescription { get; set; } = null!;
        public ClaimsIdentity? UserName { get; internal set; }
    }
}
