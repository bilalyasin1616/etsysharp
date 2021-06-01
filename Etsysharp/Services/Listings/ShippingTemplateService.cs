using Etsysharp.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Etsysharp.Services
{
    public class ShippingTemplateService : EtsyHttpService<ShippingTemplate>
    {
        ShippingTemplateUrls _apiUrls = new ShippingTemplateUrls();
        public ShippingTemplateService(OauthCredentials oauthCredentials) : base(oauthCredentials, new ShippingTemplateUrls())
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
