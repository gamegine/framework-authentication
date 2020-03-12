using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace framework_authentication.Models
{
    public class Users
    {
        private int id;
        public ICollection<Token> tokens { get; set; }
        public Token Login() => throw new NotImplementedException();
        public bool Logout(string token) => throw new NotImplementedException();
        public bool Islog(string token) => throw new NotImplementedException();
    }
}