using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace framework_authentication.Models
{
    public class UsersByName : Users
    {
        /// <summary>
        /// Identification of a user by mail or name
        /// </summary>
        public string name { get; set; }
    }
}
