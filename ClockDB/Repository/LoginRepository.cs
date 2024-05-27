using ClockDB.Data;
using ClockDB.Models;
using Microsoft.EntityFrameworkCore;

namespace ClockDB.Repository
{
    public class LoginRepository
    {
        private readonly ClockDBContext _context;

        public LoginRepository(ClockDBContext context)
        {
            _context = context;
        }

        public UserTable getUser(string username, string password)
        {
            var queryResult = _context.UserTable
                .Where(u => u.UserName == username && u.Password == password)
                .Join(_context.Role, u => u.id, r => r.RoleID, (u, r) => new UserTable
                {
                    id = u.id,
                    UserName = u.UserName,
                    FullName = u.FullName,
                    Password = u.Password,
                    RoleDescription = r.RoleDescription
                });

            return queryResult.FirstOrDefault();
        }
    }
}
