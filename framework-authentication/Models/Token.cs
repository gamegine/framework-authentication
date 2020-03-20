﻿using System;

namespace framework_authentication.Models
{
    public class Token
    {
        /// <summary>
        /// token string
        /// </summary>
        public string token { get; set; }
        /// <summary>
        /// generate new token -> string = Guid.NewGuid
        /// </summary>
        public Token()
        {
            this.token = Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
        /// <summary>
        /// checks the token validity
        /// </summary>
        /// <returns>true token is considered valid</returns>
        public virtual bool IsValid() => true;
    }
}
