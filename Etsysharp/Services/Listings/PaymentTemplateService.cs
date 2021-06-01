using Etsysharp.Entities;
using RestSharp;
using System.Linq;

namespace Etsysharp.Services
{
    public class PaymentTemplateService : EtsyHttpService<PaymentTemplate>
    {
        ShippingTemplateUrls _apiUrls = new ShippingTemplateUrls();
        public PaymentTemplateService(OauthCredentials oauthCredentials) : base(oauthCredentials, new PaymentTemplateUrls())
        {

        }

        public string GetUserId()
        {
            var request = new RestRequest(_apiUrls.FindAllShopListingDraft("__SELF__","active"));
            var result = RestClient.Get<EtsyResponseModel<Shop>>(request);
            return result.Data.results.FirstOrDefault().user_id.ToString();
        }
    }
}