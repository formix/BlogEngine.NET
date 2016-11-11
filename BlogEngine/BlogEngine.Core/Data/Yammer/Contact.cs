using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Core.Data.Yammer
{
    public class Contact
    {
        public Im im { get; set; }
        public List<PhoneNumber> phone_numbers { get; set; }
        public List<EmailAddress> email_addresses { get; set; }
        public bool has_fake_email { get; set; }
    }
}
