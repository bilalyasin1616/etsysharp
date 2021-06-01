using System;
using System.Collections.Generic;
using System.Text;

namespace Etsysharp.Entities
{
    public class OauthCredentials
    {
        public string ConsumerKey { get; set; }
        public string  ConsumerSecret { get; set; }
        public string  OauthToken { get; set; }
        public string OauthTokenSecret { get; set; }
    }
}
