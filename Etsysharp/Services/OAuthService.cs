using Etsysharp.Entities;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Etsysharp.Services
{
    public class OAuthService
    {
        string _consumerKey, _consumerSecret;
        protected RestClient restClient;
        protected OauthCredentials Oauth;
        protected IRestResponse httpResponse;
        public OAuthService(string consumerKey, string consumerSecret)
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            restClient = new RestClient(Urls.baseUrl);

        }
        protected bool ProcessResponse()
        {
            if (httpResponse.StatusCode == HttpStatusCode.Created ||
                httpResponse.StatusCode == HttpStatusCode.Found ||
                httpResponse.StatusCode == HttpStatusCode.Accepted ||
                httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                throw new Exception("Etsy didn't respond with Ok, See inner exception for detail", new Exception(httpResponse.Content));
            }
        }

        public async Task<RequestTokenResponse> RequestTokenAsync(string callBackUrl, string permissions)
        {
            restClient.Authenticator = OAuth1Authenticator.ForRequestToken(_consumerKey, _consumerSecret, callBackUrl);
            var request = new RestRequest(ApiUrls.OAuthUrls.requestToken);
            request.AddParameter("scope", permissions);
            httpResponse = await restClient.ExecuteAsync(request);
            ProcessResponse();
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(httpResponse.Content);
            return new RequestTokenResponse
            {
                LoginUrl = queryString["login_url"],
                OAuthTokenSecret = queryString["oauth_token_secret"]
            };

        }

        public async Task<AccessTokenResponse> AccessTokenAsync(string oAuthToken, string oAuthTokenSecret, string oAuthVerifier)
        {
            restClient.Authenticator = OAuth1Authenticator.ForAccessToken(
            _consumerKey, _consumerSecret, oAuthToken, oAuthTokenSecret, oAuthVerifier);
            RestRequest restRequest = new RestRequest(ApiUrls.OAuthUrls.accessToken, Method.GET);
            httpResponse = await restClient.ExecuteAsync(restRequest);
            ProcessResponse();
            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(httpResponse.Content);
            return new AccessTokenResponse
            {
                OAuthToken = queryString["oauth_token"],
                OAuthTokenSecret = queryString["oauth_token_secret"]
            };
        }
    }
}