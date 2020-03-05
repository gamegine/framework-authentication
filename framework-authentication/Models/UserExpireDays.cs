using System;
namespace framework_authentication.Models
{
    public class UserExpireDays: User
    {
        public UserExpireDays(int id, string password) : base (id, password)
        {
        }

        public string login(string password, int days)
        {
            if (this.password == password)
            {
                Token token = new Token(DateTime.Now.AddDays(days));
                this.tokens.Add(token);
                return token.getToken();
            }
            return null;
        }
    }
}
