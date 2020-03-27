using System;

namespace framework_authentication.Models
{
    public class ApiMsg
    {
        public int status { get; set; }
        public string msg { get; set; }
        public Object data { get; set; }
    }
}
