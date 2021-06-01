using Etsysharp.Entities;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
namespace Etsysharp.Services
{
    public class CountryService : BaseHttpService<Country>
    {
        public CountryService(OauthCredentials oAuthCredentials) : base(oAuthCredentials)
        {

        }
        public EtsyResponseModel<Country> GetAll()
        {
            var request = new RestRequest(ApiUrls.GetCountries);
            var response = RestClient.Get<EtsyResponseModel<Country>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
    }
}
