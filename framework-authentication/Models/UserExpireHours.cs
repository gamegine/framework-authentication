using System;
namespace framework_authentication.Models
{
    public class UserExpireHours:User
    {
        public UserExpireHours(int id, string password) : base(id, password)
        {
        }

        public string login(string password, int hours)
        {
            if (this.password == password)
            {
                Token token = new Token(DateTime.Now.AddHours(hours));
                this.tokens.Add(token);
                return token.getToken();
            }
            return null;
        }
    }
}
