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
        public Token login() => throw new NotImplementedException();
        public bool logout() => throw new NotImplementedException();
        public bool islog() => throw new NotImplementedException();
    }
}
