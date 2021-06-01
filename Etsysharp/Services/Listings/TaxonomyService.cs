using Etsysharp.Entities;
using RestSharp;
namespace Etsysharp.Services
{
    public class TaxonomyService : BaseHttpService<Taxonomy>
    {
        public TaxonomyService(OauthCredentials oAuthCredentials) : base(oAuthCredentials)
        {

        }
        public EtsyResponseModel<Taxonomy> GetAll()
        {
            var request = new RestRequest(ApiUrls.GetTaxonomy);
            var response = RestClient.Get<EtsyResponseModel<Taxonomy>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
    }
}
