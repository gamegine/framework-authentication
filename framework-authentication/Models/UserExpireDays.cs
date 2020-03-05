using System;
namespace framework_authentication.Models
{
    public class UserExpireDays: User
    {
        public UserExpireDays()
        {
        }

        public Boolean login(string password, int days)
        {
            if (this.password == password)
            {
                this.token.Add(new Token(DateTime.Now.AddDays(days)));
                return true;
            }
            return false;
        }
    }
}
