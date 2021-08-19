using Etsysharp.Entities;
using Etsysharp.Entities.Filters;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Etsysharp.Services
{
    public class ListingService : EtsyHttpService<EtsyProduct>
    {
        ListingUrls _apiUrls = new ListingUrls();
        public ListingService(OauthCredentials oauthCredentials) : base(oauthCredentials, new ListingUrls())
        {

        }

        public virtual async Task<EtsyList<EtsyProduct, ListingFilter>> GetAllShopAsync(ListingFilter listFilter)
        {
            var request = new RestRequest(_apiUrls.FindAllShopListingDraft(listFilter.ShopIdOrName, listFilter.Status), Method.GET);
            request.AddParameter("includes", _apiUrls.Includes);
            request.AddQueryParameter("limit", listFilter.Limit.ToString());
            request.AddQueryParameter("offset", listFilter.OffSet.ToString());
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<EtsyProduct>>(request);
            response.Data.results.ForEach(async listing =>
            {
                listing.ListingInventory = await GetInventoryAsync(listing.listing_id);
                listing.variantImageProperties = await VariantImagesMapAsync(listing.listing_id);
            });
            CheckResponseSuccess(response);
            return new EtsyList<EtsyProduct, ListingFilter>(listFilter, response.Data.count.GetValueOrDefault(), response.Data.results);
        }

        public virtual async Task<List<VariantImageProperty>> VariantImagesMapAsync(long listingId)
        {
            var request = new RestRequest(_apiUrls.getVariantImages(listingId), Method.GET);
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<VariantImageProperty>>(request);
            CheckResponseSuccess(response);
            return response.Data.results;
        }

        public virtual async Task<EtsyProduct> GetListingAsync(long id)
        {
            var request = new RestRequest(_apiUrls.Get(id), Method.GET);
            request.AddParameter("includes", _apiUrls.Includes);
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<EtsyProduct>>(request);
            response.Data.results[0].ListingInventory = await GetInventoryAsync(id);
            return response.Data.results[0];
        }

        public virtual async Task<ListingInventory> GetInventoryAsync(long listingId)
        {
            var request = new RestRequest(_apiUrls.GetInventory(listingId), Method.GET);
            request.AddParameter("write_missing_inventory", 1);
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<ListingInventory>>(request);
            CheckResponseSuccess(response);
            return response.Data.results.First();
        }

        public virtual async Task<EtsyResponseModel<ListingInventory>> UpdateInventoryAsync(EtsyRequestListingInventory inventory, long listing_id)
        {
            var request = new RestRequest(_apiUrls.UpdateInventory(listing_id), Method.PUT);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddObject(new
            {
                products = JsonConvert.SerializeObject(inventory.products),
                price_on_property = inventory.price_on_property.ToArray(),
                quantity_on_property = inventory.quantity_on_property.ToArray(),
                sku_on_property = inventory.sku_on_property.ToArray()
            });
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<ListingInventory>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }

        public virtual async Task<EtsyResponseModel<ListingAttribute>> GetAttributesAsync(long listing_id)
        {
            var request = new RestRequest(_apiUrls.GetAttributes(listing_id), Method.GET);
            var response = await RestClient.ExecuteAsync< EtsyResponseModel < ListingAttribute >> (request);
            CheckResponseSuccess(response);
            return response.Data;
        }

        public virtual async Task<EtsyResponseModel<ListingAttribute>> UpdateAttributeAsync(ListingAttribute attribute)
        {
            var request = new RestRequest(_apiUrls.UpdateAttribute(attribute.listing_id.GetValueOrDefault(), attribute.property_id), Method.PUT);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddObject(attribute);
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<ListingAttribute>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public virtual async Task<EtsyResponseModel<ListingAttribute>> DeleteAttributeAsync(int listing_id, int property_id)
        {
            var request = new RestRequest(_apiUrls.DeleteAttribute(listing_id,property_id), Method.DELETE);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<ListingAttribute>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public virtual async Task<EtsyResponseModel<ListingImage>> GetAllListingImagesAsync(long listingId)
        {
            var request = new RestRequest(_apiUrls.findAllListingImages(listingId), Method.GET);
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<ListingImage>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public virtual async Task<EtsyResponseModel<ListingImage>> DeleteListingImageAsync(long listingId, long imageId)
        {
            var request = new RestRequest(_apiUrls.deleteListingImage(listingId, imageId), Method.DELETE);
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<ListingImage>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public virtual async Task<EtsyResponseModel<ListingImage>> UploadListingImageAsync (long listingId, byte[] fileBytes)
        {
            var request = new RestRequest(_apiUrls.uploadListingImage(listingId), Method.POST);
            request.AddFileBytes("image", fileBytes, "image", "multipart/form-dataheader");
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<ListingImage>>(request);
             CheckResponseSuccess(response);
            return response.Data;
        }
        public virtual async Task<EtsyResponseModel<List<ListingImage>>> UploadListingImageByUrlAsync(long listingId, string image_url)
        {
            var request = new RestRequest(_apiUrls.uploadListingImage(listingId), Method.POST);
            WebClient wc = new WebClient();
            var bytes = wc.DownloadData(image_url);
            request.AddFileBytes("image", bytes, "image", "multipart/form-dataheader");
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<List<ListingImage>>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public virtual async Task<VariationImage> UploadListingInventoryImageByUrlAsync(long listingId,string image_url,long propertyId,long valueId)
        {
            var request = new RestRequest(_apiUrls.uploadListingImage(listingId), Method.POST);
            WebClient wc = new WebClient();
            var bytes = wc.DownloadData(image_url);
            request.AddFileBytes("image", bytes, "image", "multipart/form-dataheader");
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<List<ListingImage>>>(request);
            return new VariationImage
            {
                property_id = propertyId,
                value_id = valueId,
                image_id = response.Data.results.FirstOrDefault().FirstOrDefault().listing_image_id,
                // Commented By Abdullah Zafar
                //is_for_channel = true,
                //image_url = image_url
            };
        }
        public virtual async Task LinkListingInventoryImagesAsync(long listingId,List<VariationImage> variationImages)
        {
            var request = new RestRequest(_apiUrls.updateVariantImages(listingId), Method.POST);
            request.AddObject(new
            {
                listing_id = listingId,
                variation_images = JsonConvert.SerializeObject(variationImages)
            });
            await RestClient.ExecuteAsync(request);
        }
        public virtual async Task<EtsyResponseModel<List<ListingImage>>> UpdateVariationImagesAsync(ListingVariationImages listingVariantImages)
        {
            var request = new RestRequest(_apiUrls.updateVariantImages(listingVariantImages.listing_id), Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddObject(new
            {
              listing_id = listingVariantImages.listing_id,
              variation_images = JsonConvert.SerializeObject(listingVariantImages.variation_images.Where(x=>x.is_for_channel))
            });
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<List<ListingImage>>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public virtual async Task<EtsyResponseModel<List<EtsyProduct>>> UpdateAsync(EtsyProduct p)
        {
            var request = new RestRequest(_apiUrls.Update(p.listing_id), Method.PUT);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddObject(new
            {
                p.title, p.description,p.state, p.item_dimensions_unit, p.item_height,
                p.item_length, p.item_width, p.item_weight_unit, p.item_weight,
                tags=string.Join(",",p.tags), p.who_made
            });
            if (p.taxonomy_id != 0)
                request.AddParameter("taxonomy_id", p.taxonomy_id);
            if (p.shipping_template_id != 0)
                request.AddParameter("shipping_template_id", p.shipping_template_id);
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<List<EtsyProduct>>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public override async Task<EtsyResponseModel<EtsyProduct>> CreateAsync(EtsyProduct p)
        {
            var request = new RestRequest(_apiUrls.Create(), Method.POST);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddObject(new
            {
                p. title,
                p. description,
                sku=string.Join(',',p. sku),
                tags=string.Join(',',p. tags),
                p. price ,
                p. non_taxable,
                p. item_height,
                p. item_length,
                p. item_width ,
                p. item_weight,
                p. item_dimensions_unit,
                p. can_write_inventory,
                p. currency_code,
                p. quantity,
                p. who_made ,
                p. is_supply,
                p. when_made ,
                p. state ,
                p. has_variations,
                p. shipping_template_id,
                p. taxonomy_id
            });
            var response = await RestClient.ExecuteAsync<EtsyResponseModel<EtsyProduct>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
    }
}