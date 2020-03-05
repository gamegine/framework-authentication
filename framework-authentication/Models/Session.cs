using System;
namespace framework_authentication.Models
{
    public class Session
    {
        private Token token;
        public Session(Token token)
        {
            this.token = token;
        }

        public void Close()
        {
            token.delete();
        }
    }
}
