using Etsysharp.Entities;
using Etsysharp.Entities.Filters;
using RestSharp;
using System.Dynamic;

namespace Etsysharp.Services
{
    public class ReceiptService : BaseHttpService<object>
    {
        public ReceiptService(OauthCredentials oAuthCredentials) : base(oAuthCredentials)
        {

        }
        public async System.Threading.Tasks.Task<EtsyList<EtsyReceipt, ReceiptingFilter>> GetAllShopReceiptsAsync(ReceiptingFilter receiptFilter)
        {
            var request = new RestRequest(ApiUrls.ReceiptUrl.GetAllShopReceipts(receiptFilter.ShopIdOrName), Method.GET);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddParameter("includes", ApiUrls.ReceiptUrl.Includes);
            request.AddQueryParameter("limit", receiptFilter.Limit.ToString());
            request.AddQueryParameter("offset", receiptFilter.OffSet.ToString());
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<EtsyReceipt>>(request);
            CheckResponseSuccess(response);
            return new EtsyList<EtsyReceipt, ReceiptingFilter>(receiptFilter, response.Data.count.GetValueOrDefault(), response.Data.results);
        }

        public class UpdateReceiptBody
        {
            public long receipt_id { get; set; }
            public bool was_shipped { get; set; }
            public bool was_paid { get; set; }
        }



        public void SubmitTracking(long receiptId,string trackingCode,string carrierName)
        {
            var request = new RestRequest(ApiUrls.ReceiptUrl.SubmitTracking("__SELF__", receiptId));
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddObject(new TrackingModel {
                carrier_name = carrierName,
                tracking_code = trackingCode,
                send_bcc = true
            });
            var response = RestClient.Post(request);
            CheckResponseSuccess(response);
        }

        public void Fulfill(long receiptId)
        {
            var request = new RestRequest(ApiUrls.ReceiptUrl.UpdateReceipt(receiptId));
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddObject(new UpdateReceiptBody
            {
                receipt_id = receiptId,
                was_shipped = true
            });
            var response = RestClient.Put(request);
            CheckResponseSuccess(response);
        }
    }
}