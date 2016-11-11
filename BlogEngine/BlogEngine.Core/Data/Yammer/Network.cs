using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Core.Data.Yammer
{
    public class Network
    {
        public string type { get; set; }
        public int id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public bool community { get; set; }
        public string permalink { get; set; }
        public string web_url { get; set; }
        public bool show_upgrade_banner { get; set; }
        public string header_background_color { get; set; }
        public string header_text_color { get; set; }
        public string navigation_background_color { get; set; }
        public string navigation_text_color { get; set; }
        public bool paid { get; set; }
        public bool moderated { get; set; }
        public bool is_org_chart_enabled { get; set; }
        public bool is_group_enabled { get; set; }
        public bool is_chat_enabled { get; set; }
        public bool is_translation_enabled { get; set; }
        public string created_at { get; set; }
        public ProfileFieldsConfig profile_fields_config { get; set; }
        public object browser_deprecation_url { get; set; }
        public string external_messaging_state { get; set; }
        public string state { get; set; }
    }
}
