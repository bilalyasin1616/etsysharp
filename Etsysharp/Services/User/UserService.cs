using Etsysharp.Entities;
using RestSharp;
using System.Threading.Tasks;

namespace Etsysharp.Services
{
    public class UserService : EtsyHttpService<User>
    {
        UserUrls _apiUrls = new UserUrls();
        public UserService(OauthCredentials oauthCredentials) : base(oauthCredentials, new UserUrls())
        {

        }

        public async Task<EtsyResponseModel<User>> ScopesAsync()
        {
            var request = new RestRequest(UserUrls.OauthScopes(), Method.GET);
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<User>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
    }
}