using System.Collections.Generic;

namespace framework_authentication.Models
{
    public class Users
    {
        /// <summary>
        /// user id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// user session tokens list
        /// </summary>
        public virtual ICollection<Token> tokens { get; set; }
        /// <summary>
        /// login user -> add new token to users.tokens []
        /// </summary>
        /// <returns>new token generated</returns>
        public Token Login()
        {
            Token t = new Token();
            this.tokens.Add(t);
            return t;
        }
        /// <summary>
        /// logout user -> delete token (str token) in users.tokens []
        /// </summary>
        /// <param name="token">Token string</param>
        /// <returns>false if fail</returns>
        public bool Logout(string token)
        {
            foreach (Token t in this.tokens)
                if (t.token == token)
                {
                    this.tokens.Remove(t);
                    return true;
                }
            return false;
        }
        /// <summary>
        /// checks the user token exists and is valid
        /// </summary>
        /// <param name="token">Token string</param>
        /// <returns>token validity</returns>
        public bool Islog(string token)
        {
            foreach (Token t in this.tokens)
                if (t.token == token)
                    return t.IsValid();
            return false;
        }
    }
}