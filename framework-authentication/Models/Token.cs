using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace framework_authentication.Models
{
    public class Token
    {
        private string token;
        private DateTime expireDate;

        public Token()
        {

        }

        public Token(DateTime expireDate)
        {
            this.expireDate = expireDate;
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

        public DateTime getExpirationDate()
        {
            return this.expireDate;
        }

    }
}
