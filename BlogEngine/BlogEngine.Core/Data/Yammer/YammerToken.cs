using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Core.Data.Yammer
{
    public class YammerToken
    {
        public AccessToken access_token { get; set; }
        public User user { get; set; }
        public Network network { get; set; }
    }
}
