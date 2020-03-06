using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace framework_authentication.Models
{
    public class Token
    {
        public string token;
        private DateTime expireDate;
        private bool valid;
        private bool expires;

        public Token()
        {
            this.valid = true;
            this.token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            this.expires = false;
        }
        public Token(string token)
        {
            this.token = token;
            this.expires = false;

        }

        public Token(DateTime expireDate)
        {
            this.valid = true;
            this.token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
            this.expireDate = expireDate;
            this.expires = true;

        }

        public bool isValid()
        {
            if (this.valid)
            {
                if (this.expires)
                {
                    if (this.expireDate > DateTime.Now)
                    {
                        return true;
                    }
                    return false;
                }
                return true;
            }
            return false;                       
        }

        public bool delete()
        {
            this.valid = false;
            this.token = null;
            return true;
        }

        public string getToken()
        {
            return this.token;
        }

        public DateTime getExpirationDate()
        {
            return this.expireDate;
        }

    }
}
