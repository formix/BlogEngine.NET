namespace BlogEngine.Core.Web.HttpHandlers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Web;
    using Newtonsoft.Json;

    using BlogEngine.Core.Data.Yammer;
    using System.Web.Security;
    using System.Web.Configuration;
    using System.Runtime.Caching;

    /// <summary>
    /// Handle Yammer signon.
    /// </summary>
    public class YammerSingleSignOn : IHttpHandler
    {
        private static string _clientId = null;
        private static string _clientSecret = null;
        private static string _allowedNetworkName;

        /// <summary>
        /// Tells that the hender is resulable across requests.
        /// </summary>
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets the client ID.
        /// </summary>
        public static string ClientId
        {
            get
            {
                if (_clientId == null)
                {
                    _clientId = Environment.GetEnvironmentVariable("APPSETTING_voicesClientId") ?? "";
                }
                return _clientId;
            }
        }

        /// <summary>
        /// Gets the client secret.
        /// </summary>
        public static string ClientSecret
        {
            get
            {
                if (_clientSecret == null)
                {
                    _clientSecret = Environment.GetEnvironmentVariable("APPSETTING_voicesClientSecret") ?? "";
                }
                return _clientSecret;
            }
        }

        /// <summary>
        /// Return the yammer allowed network name.
        /// </summary>
        public static string AllowedNetworkName
        {
            get
            {
                if (_allowedNetworkName == null)
                {
                    _allowedNetworkName = WebConfigurationManager.AppSettings["Voices.AllowedNetworkName"] ?? "";
                }
                return _allowedNetworkName;
            }
        }

        /// <summary>
        /// Execut the html request for the current handler.
        /// </summary>
        /// <param name="context"></param>
        public void ProcessRequest(HttpContext context)
        {
            var code = context.Request.QueryString["code"];
            if (code == null)
            {
                context.Response.StatusCode = 400;  // bad request
                context.Response.End();
                return;
            }

            var tokenUrl = new Uri(string.Format(
                "https://www.yammer.com/oauth2/access_token.json?client_id={0}&client_secret={1}&code={2}",
                ClientId,
                ClientSecret,
                code));

            var token = GetToken(tokenUrl);

            if (token.access_token.network_name != AllowedNetworkName)
            {
                context.Response.StatusCode = 403; // forbidden
                context.Response.End();
                return;
            }

            CreateUserIfNeeded(token);

            bool authenticated = AuthenticateUser(token);
            if (!authenticated)
            {
                context.Response.StatusCode = 403;  // forbidden
                context.Response.End();
                return;
            }
        }

        private bool AuthenticateUser(YammerToken token)
        {
            return Security.AuthenticateUser(token.user.name, GeneratePassword(token), false, token.access_token.token);
        }

        private void CreateUserIfNeeded(YammerToken token)
        {
            var user = Membership.GetUser(token.user.name);

            if (user == null)
            {
                int totalRecords = 0;
                Membership.GetAllUsers(0, 3, out totalRecords);

                Membership.CreateUser(
                    token.user.name,
                    GeneratePassword(token),
                    token.user.email);

                if (totalRecords == 1)
                {
                    // Means that there is only the default and unuseable admin 
                    // in the user table. We give the admin rights to that 
                    // first user then.
                    Roles.AddUserToRole(token.user.name, "Administrators");
                }
                else
                {
                    // Everyone else is an editor from now on.
                    Roles.AddUserToRole(token.user.name, "Editors");
                }
            }


        }

        private string GeneratePassword(YammerToken token)
        {
            return string.Format("{0}_{1}", token.user.name, token.user.id);
        }

        private YammerToken GetToken(Uri tokenUrl)
        {
            var response = WebRequest
                .Create(tokenUrl)
                .GetResponse();

            string json = null;
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                json = sr.ReadToEnd();
            }

            var token = JsonConvert.DeserializeObject<YammerToken>(json);

            return token;
        }

    }
}
