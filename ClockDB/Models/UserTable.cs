using Azure.Identity;
using Microsoft.Build.Framework;

namespace ClockDB.Models
{
    public class UserTable
    {
        public int id { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string RoleDescription { get; set; } = null!;

    }

    public class userLogin
    {
        [Required]
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
