using Etsysharp.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Etsysharp.Services
{
    public class ShopService : EtsyHttpService<Shop>
    {
        public ShopService(OauthCredentials oauthCredentials) : base(oauthCredentials, new ShopUrls())
        {

        }


        public EtsyResponseModel<Shop> FindAllUserShops()
        {
            var request = new RestRequest(ShopUrls.FindAllUserShops("__SELF__"));
            var response = RestClient.Get<EtsyResponseModel<Shop>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }

        public Shop GetMyShop()
        {
            var request = new RestRequest(ShopUrls.Get("__SELF__"));
            var response = RestClient.Get<EtsyResponseModel<Shop>>(request);
            CheckResponseSuccess(response);
            return response.Data.results.First();
        }
    }
}