using Etsysharp.Entities;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Net;

namespace Etsysharp.Services
{
    public class BaseHttpService<T>
    {
        protected RestClient RestClient { get; set; }
        protected OauthCredentials Oauth { get; set; }
        protected IRestResponse HttpResponse { get; set; }
        public BaseHttpService(OauthCredentials oauthCredentials)
        {
            Oauth = oauthCredentials;
            RestClient = new RestClient(Urls.baseUrl);
            RestClient.Authenticator = OAuth1Authenticator.ForProtectedResource(
            Oauth.ConsumerKey, Oauth.ConsumerSecret, Oauth.OauthToken, Oauth.OauthTokenSecret);
        }
        public BaseHttpService()
        {
            RestClient = new RestClient(Urls.baseUrl);
        }
        protected void CheckResponseSuccess(IRestResponse restResponse)
        {
            if (restResponse.StatusCode == HttpStatusCode.Created ||
                restResponse.StatusCode == HttpStatusCode.Found ||
                restResponse.StatusCode == HttpStatusCode.Accepted ||
                restResponse.StatusCode == HttpStatusCode.OK)
            {
                return;
            }
            else
            {
                throw new Exception("Etsy didn't respond with success", new Exception(restResponse.Content));
            }
        }
    }
}
