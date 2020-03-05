using System;
using System.Collections.Generic;

namespace framework_authentication.Models
{
    public class User
    {
        private int id;
        protected string password;
        public string userName { get; set; }
        public List<Token> tokens { get; set; }
        public User()
        {
        }
        public User(int id, string password)
        {
            //verifie dans la database
            this.tokens = new List<Token>();
            this.id = id;
            this.password = password;

        }

        public string login(string password)
        {
            if(this.password == password)
            {
                Token token = new Token();
                this.tokens.Add(token);
                return token.getToken();
            }
            return null;
        }

        public bool logout(string token)
        {
            foreach(Token t in this.tokens){
                if(t.token == token)
                {
                    t.delete();
                    this.tokens.Remove(t);
                    return true;
                }
            }
            return false;
        }
        public bool islog()
        {
            foreach (Token t in this.tokens)
            {
                if (t.isValid())
                {
                    return true;
                }
            }
            return false;
        }
    }
}
