using System;
using System.Collections.Generic;

namespace framework_authentication.Models
{
    public class User
    {
        private int id;
        protected string password;
        public string userName { get; set; }
        public List<Token> token { get; set; }
        public User()
        {
        }
        public User(int id, string password)
        {
            //verifie dans la database
            this.id = id;
            this.password = password;

        }

        public Boolean login(string password)
        {
            if(this.password == password)
            {
                this.token.Add(new Token());
                return true;
            }
            return false;
        }

        public bool logout(string token)
        {
            return true;
        }
        public bool islog(string token)
        {
            return true;
        }
    }
}
