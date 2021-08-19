using Etsysharp.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Etsysharp.Services
{
    public class CountryService : BaseHttpService<Country>
    {
        public CountryService(OauthCredentials oAuthCredentials) : base(oAuthCredentials)
        {

        }
        public virtual async Task<EtsyResponseModel<Country>> GetAllAsync()
        {
            var request = new RestRequest(ApiUrls.GetCountries, Method.GET);
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<Country>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
    }
}
