using Etsysharp.Entities;
using RestSharp;
using System.Threading.Tasks;

namespace Etsysharp.Services
{
    public class EtsyHttpService<T> : BaseHttpService<T> where T : EtsyEntity
    {
        ApiUrls _apiUrls;
        public EtsyHttpService(OauthCredentials oauthCredentials, ApiUrls apiUrls) : base(oauthCredentials)
        {
            _apiUrls = apiUrls;
        }
        public EtsyHttpService(ApiUrls apiUrls)
        {
            _apiUrls = apiUrls;
            RestClient = new RestClient(Urls.baseUrl);
        }
        public virtual async Task<EtsyResponseModel<T>> GetAllAsync(string status)
        {
            var request = new RestRequest(_apiUrls.GetAll(status), Method.GET);
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<T>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }

        public virtual async Task<EtsyResponseModel<T>> CreateAsync(T entity)
        {
            var request = new RestRequest(_apiUrls.Create(), Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddObject(entity);
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<T>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }

        public virtual async Task<EtsyResponseModel<T>> UpdateAsync(T entity, long id)
        {
            var request = new RestRequest(_apiUrls.Update(id), Method.PUT);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddObject(entity);
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<T>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }

        public virtual async Task<EtsyResponseModel<T>> GetAsync(long id)
        {
            var request = new RestRequest(_apiUrls.Get(id), Method.GET);
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<T>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }

        public virtual async Task<EtsyResponseModel<T>> DeleteAsync(long id)
        {
            var request = new RestRequest(_apiUrls.Delete(id), Method.DELETE);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<T>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }

    }
}