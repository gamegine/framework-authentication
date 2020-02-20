using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace framework_authentication
{
    public class Token
    {
        private string token;
        private DateTime expireDate;

        public Token()
        {

        }

        public bool isValid()
        {
            return true;
        }

        public bool delete()
        {
            return true;
        }

        public string getToken()
        {
            return "";
        }

    }
}
