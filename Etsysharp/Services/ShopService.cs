using Etsysharp.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etsysharp.Services
{
    public class ShopService : EtsyHttpService<Shop>
    {
        public ShopService(OauthCredentials oauthCredentials) : base(oauthCredentials, new ShopUrls())
        {

        }


        public async Task<EtsyResponseModel<Shop>> FindAllUserShopsAsync()
        {
            var request = new RestRequest(ShopUrls.FindAllUserShops("__SELF__"), Method.GET);
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<Shop>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }

        public async Task<Shop> GetMyShopAsync()
        {
            var request = new RestRequest(ShopUrls.Get("__SELF__"), Method.GET);
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<Shop>>(request);
            CheckResponseSuccess(response);
            return response.Data.results.First();
        }
    }
}