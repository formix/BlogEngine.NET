using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlogEngine.Core.Data.Yammer
{
    /// <summary>
    /// This is a yammer message model to post to 
    /// https://developer.yammer.com/docs/messages-json-post
    /// </summary>
    public class YammerMessage
    {
        /// <summary>
        /// Creates an empty yammer message.
        /// </summary>
        public YammerMessage()
            : this("")
        {
        }

        /// <summary>
        /// Creates a Yammer message with the given body.
        /// </summary>
        /// <param name="body">The text of the message to publish.</param>
        public YammerMessage(string body)
        {
            Body = body;
            DirectToUserIds = new List<int>();
        }

        /// <summary>
        /// Gets or sets the body of the message.
        /// </summary>
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the DirectToUserIds of the message.
        /// </summary>
        [JsonProperty(PropertyName = "direct_to_user_ids")]
        public List<int> DirectToUserIds { get; set; }
    }
}
