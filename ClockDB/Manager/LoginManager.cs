using ClockDB.Data;
using ClockDB.Models;
using ClockDB.Repository;

namespace ClockDB.Manager
{
    public class LoginManager
    {
        private readonly LoginRepository _loginRepository;

        public LoginManager(ClockDBContext context)
        {
            _loginRepository = new LoginRepository(context);
        }

        public UserTable getUser(string username, string password)
        {
            return _loginRepository.getUser(username, password);
        }
    }
}
