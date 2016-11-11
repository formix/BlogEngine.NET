using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Core.Data.Yammer
{
    public class User
    {
        public string type { get; set; }
        public int id { get; set; }
        public int network_id { get; set; }
        public string state { get; set; }
        public object guid { get; set; }
        public string job_title { get; set; }
        public string location { get; set; }
        public string significant_other { get; set; }
        public string kids_names { get; set; }
        public string interests { get; set; }
        public string summary { get; set; }
        public string expertise { get; set; }
        public string full_name { get; set; }
        public string activated_at { get; set; }
        public bool auto_activated { get; set; }
        public bool show_ask_for_photo { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string network_name { get; set; }
        public List<string> network_domains { get; set; }
        public string url { get; set; }
        public string web_url { get; set; }
        public string name { get; set; }
        public string mugshot_url { get; set; }
        public string mugshot_url_template { get; set; }
        public string birth_date { get; set; }
        public BirthDateComplete birth_date_complete { get; set; }
        public string timezone { get; set; }
        public List<object> external_urls { get; set; }
        public string admin { get; set; }
        public string verified_admin { get; set; }
        public string supervisor_admin { get; set; }
        public string can_broadcast { get; set; }
        public string department { get; set; }
        public string email { get; set; }
        public bool can_create_new_network { get; set; }
        public bool can_browse_external_networks { get; set; }
        public List<object> previous_companies { get; set; }
        public List<object> schools { get; set; }
        public Contact contact { get; set; }
        public Stats stats { get; set; }
        public Settings settings { get; set; }
        public bool show_invite_lightbox { get; set; }
    }
}
