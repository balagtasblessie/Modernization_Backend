using ClockDB.Models;

namespace ClockDB.Validator
{
    public class LoginValidator
    {
        public LoginValidator() { 

        }

        public bool isValid(userLogin request)
        {
            if (request == null || string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                return false;
            }

            return true;
        }

    }
}
