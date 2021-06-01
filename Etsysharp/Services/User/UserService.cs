using Etsysharp.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Etsysharp.Services
{
    public class UserService : EtsyHttpService<User>
    {
        UserUrls _apiUrls = new UserUrls();
        public UserService(OauthCredentials oauthCredentials) : base(oauthCredentials, new UserUrls())
        {

        }

        public EtsyResponseModel<User> Scopes()
        {
            var request = new RestRequest(UserUrls.OauthScopes());
            var response = RestClient.Get<EtsyResponseModel<User>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
    }
}