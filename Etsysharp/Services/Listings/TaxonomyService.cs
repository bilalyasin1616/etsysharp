using Etsysharp.Entities;
using RestSharp;
namespace Etsysharp.Services
{
    public class TaxonomyService : BaseHttpService<Taxonomy>
    {
        public TaxonomyService(OauthCredentials oAuthCredentials) : base(oAuthCredentials)
        {

        }
        public virtual async System.Threading.Tasks.Task<EtsyResponseModel<Taxonomy>> GetAllAsync()
        {
            var request = new RestRequest(ApiUrls.GetTaxonomy, Method.GET);
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<Taxonomy>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
    }
}
