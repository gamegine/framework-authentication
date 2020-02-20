using System;
using System.Collections.Generic;

namespace framework_authentication.Models
{
    public class User
    {
        private string id;
        private List<Token> tokens;

        public User()
        {
  
        }

        public bool login()
        {
            return true;
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
