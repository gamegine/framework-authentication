using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace framework_authentication.Models
{
    public class TokenExpireHours : Token
    {
        /// <summary>
        /// creation date
        /// </summary>
        public DateTime date {get; set;}

        public TokenExpireHours() : base()
        {
            this.date = DateTime.Now;
        }

        public override bool IsValid()
        {
            return (this.date > DateTime.Now.AddHours(-1));
        }
    }
}
