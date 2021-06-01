using Etsysharp.Entities;
using RestSharp;

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
        public virtual EtsyResponseModel<T> GetAll(string status)
        {
            var request = new RestRequest(_apiUrls.GetAll(status));
            var response = RestClient.Get<EtsyResponseModel<T>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public virtual EtsyResponseModel<T> Create(T entity)
        {
            var request = new RestRequest(_apiUrls.Create());
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddObject(entity);
            var response = RestClient.Post<EtsyResponseModel<T>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public virtual EtsyResponseModel<T> Update(T entity, long id)
        {
            var request = new RestRequest(_apiUrls.Update(id));
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddObject(entity);
            var response = RestClient.Put<EtsyResponseModel<T>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public virtual EtsyResponseModel<T> Get(long id)
        {
            var request = new RestRequest(_apiUrls.Get(id));
            var response = RestClient.Get<EtsyResponseModel<T>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public virtual EtsyResponseModel<T> Delete(long id)
        {
            var request = new RestRequest(_apiUrls.Delete(id));
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            var response = RestClient.Delete<EtsyResponseModel<T>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }

    }
}