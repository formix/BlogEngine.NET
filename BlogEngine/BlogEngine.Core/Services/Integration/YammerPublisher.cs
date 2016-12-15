using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BlogEngine.Core.Data.Yammer;
using Newtonsoft.Json;

namespace BlogEngine.Core.Services.Integration
{
    public class YammerPublisher
    {
        private const string MESSAGE_API_URL = "https://www.yammer.com/api/v1/messages.json";


        public void PublishNew(Post post)
        {
            Publish(post, "I wrote a new blog post");
        }

        public void PublishUpdate(Post post)
        {
            Publish(post, "I updated my blog post");
        }

        private void Publish(Post post, string messageIntro)
        {
            var postLink = post.PermaLink;
            var identity = (CustomIdentity)Security.CurrentUser.Identity;
            var yammerToken = identity.UserData;

            Task.Run(() =>
            {
                var tags = CreateTags(post);
                var message = new YammerMessage(
                    $"{messageIntro} '{post.Title}'. Please give me your feedbacks!\n{postLink}\n{tags}");

                var request = WebRequest
                    .Create(MESSAGE_API_URL);

                request.Method = "POST";

                request.Headers.Add(HttpRequestHeader.Authorization, $"Bearer {yammerToken}");
                request.ContentType = "application/json";

                var json = JsonConvert.SerializeObject(message);
                using (var rs = request.GetRequestStream())
                {
                    var data = Encoding.UTF8.GetBytes(json);
                    rs.Write(data, 0, data.Length);
                }

                request.GetResponse();
            });
        }

        private string CreateTags(Post post)
        {
            var sb = new StringBuilder();
            foreach (var tag in post.Tags)
            {
                if (sb.Length > 0)
                {
                    sb.Append(' ');
                }
                sb.AppendFormat("#{0}", tag);
            }

            if (sb.Length > 0)
            {
                sb.Insert(0, "\n\n");
            }

            return sb.ToString();
        }

    }
}
