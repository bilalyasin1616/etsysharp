using Etsysharp.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
namespace Etsysharp.Services
{
    public class CartService : BaseHttpService<object>
    {
        public CartService(OauthCredentials oAuthCredentials) : base(oAuthCredentials)
        {

        }
        public EtsyResponseModel<List<Taxonomy>> GetAllUserCarts(long userid)
        {
            var request = new RestRequest(ApiUrls.CartUrl.GetAllUserCarts(userid));
            var response = RestClient.Get<EtsyResponseModel<List<Taxonomy>>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
    }
}
