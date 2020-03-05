using System;
namespace framework_authentication.Models
{
    public class UserExpireHours:User
    {
        public UserExpireHours()
        {
        }

        public Boolean login(string password, int hours)
        {
            if (this.password == password)
            {
                this.token.Add(new Token(DateTime.Now.AddHours(hours)));
                return true;
            }
            return false;
        }
    }
}
