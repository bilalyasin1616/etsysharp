using Etsysharp.Entities;
using RestSharp;
using System.Linq;
using System.Threading.Tasks;

namespace Etsysharp.Services
{
    public class ShippingTemplateService : EtsyHttpService<ShippingTemplate>
    {
        ShippingTemplateUrls _apiUrls = new ShippingTemplateUrls();
        public ShippingTemplateService(OauthCredentials oauthCredentials) : base(oauthCredentials, new ShippingTemplateUrls())
        {

        }

        public virtual async Task<string> GetUserIdAsync()
        {
            var request = new RestRequest(_apiUrls.FindAllShopListingDraft("__SELF__","active"), Method.GET);
            var result = await RestClient.ExecuteAsync<EtsyResponseModel<Shop>>(request);
            return result.Data.results.FirstOrDefault().user_id.ToString();
        }
    }
}
