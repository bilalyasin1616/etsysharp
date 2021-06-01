using System;
using System.Collections.Generic;
using System.Text;

namespace Etsysharp.Entities
{
    public class RequestTokenResponse
    {
        public  string LoginUrl { get; set; }
        public string OAuthTokenSecret { get; set; }
    }
    public class AccessTokenResponse
    {
        public string OAuthToken { get; set; }
        public string OAuthTokenSecret { get; set; }
    }
}
