using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace framework_authentication.Models
{
    public class Token
    {
        public string token { get; set; }
        public Token() => throw new NotImplementedException();
        public bool IsValid() => throw new NotImplementedException();
    }
}
