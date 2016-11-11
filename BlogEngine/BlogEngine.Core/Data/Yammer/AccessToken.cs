using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Core.Data.Yammer
{
    public class AccessToken
    {
        public int user_id { get; set; }
        public int network_id { get; set; }
        public string network_permalink { get; set; }
        public string network_name { get; set; }
        public string token { get; set; }
        public bool view_members { get; set; }
        public bool view_groups { get; set; }
        public bool view_messages { get; set; }
        public bool view_subscriptions { get; set; }
        public bool modify_subscriptions { get; set; }
        public bool modify_messages { get; set; }
        public bool view_tags { get; set; }
        public string created_at { get; set; }
        public string authorized_at { get; set; }
        public object expires_at { get; set; }
    }
}
