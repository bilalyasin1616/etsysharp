using Etsysharp.Entities;
using RestSharp;
using System.Collections.Generic;
namespace Etsysharp.Services
{
    public class CartService : BaseHttpService<object>
    {
        public CartService(OauthCredentials oAuthCredentials) : base(oAuthCredentials)
        {

        }
        public async System.Threading.Tasks.Task<EtsyResponseModel<List<Taxonomy>>> GetAllUserCartsAsync(long userid)
        {
            var request = new RestRequest(ApiUrls.CartUrl.GetAllUserCarts(userid), Method.GET);
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<List<Taxonomy>>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
    }
}
