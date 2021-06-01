using Etsysharp.Entities;
using Etsysharp.Entities.Filters;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Etsysharp.Services
{
    public class ListingService : EtsyHttpService<EtsyProduct>
    {
        ListingUrls _apiUrls = new ListingUrls();
        public ListingService(OauthCredentials oauthCredentials) : base(oauthCredentials, new ListingUrls())
        {

        }
        public EtsyList<EtsyProduct,ListingFilter> GetAllShop(ListingFilter listFilter)
        {
            var request = new RestRequest(_apiUrls.FindAllShopListingDraft(listFilter.ShopIdOrName, listFilter.Status));
            request.AddParameter("includes", _apiUrls.Includes);
            request.AddQueryParameter("limit", listFilter.Limit.ToString());
            request.AddQueryParameter("offset", listFilter.OffSet.ToString());
            var response = RestClient.Get<EtsyResponseModel<EtsyProduct>>(request);
            response.Data.results.ForEach(listing =>
            {
                listing.ListingInventory = GetInventory(listing.listing_id);
                listing.variantImageProperties = VariantImagesMap(listing.listing_id);
            });
            CheckResponseSuccess(response);
            return new EtsyList<EtsyProduct, ListingFilter>(listFilter, response.Data.count.GetValueOrDefault(), response.Data.results);
        }

        public List<VariantImageProperty> VariantImagesMap(long listingId)
        {
            var request = new RestRequest(_apiUrls.getVariantImages(listingId));
            var response = RestClient.Get<EtsyResponseModel<VariantImageProperty>>(request);
            CheckResponseSuccess(response);
            return response.Data.results;
        }

        public EtsyProduct GetListing(long id)
        {
            var request = new RestRequest(_apiUrls.Get(id));
            request.AddParameter("includes", _apiUrls.Includes);
            var response = RestClient.Get<EtsyResponseModel<EtsyProduct>>(request);
            response.Data.results[0].ListingInventory = GetInventory(id);
            return response.Data.results[0];
        }

        public ListingInventory GetInventory(long listingId)
        {
            var request = new RestRequest(_apiUrls.GetInventory(listingId));
            request.AddParameter("write_missing_inventory", 1);
            var response = RestClient.Get<EtsyResponseModel<ListingInventory>>(request);
            CheckResponseSuccess(response);
            return response.Data.results.First();
        }
        public EtsyResponseModel<ListingInventory> UpdateInventory(EtsyRequestListingInventory inventory, long listing_id)
        {
            var request = new RestRequest(_apiUrls.UpdateInventory(listing_id));
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddObject(new
            {
                products = JsonConvert.SerializeObject(inventory.products),
                price_on_property = inventory.price_on_property.ToArray(),
                quantity_on_property = inventory.quantity_on_property.ToArray(),
                sku_on_property = inventory.sku_on_property.ToArray()
            });
            var response = RestClient.Put<EtsyResponseModel<ListingInventory>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public EtsyResponseModel<ListingAttribute> GetAttributes(long listing_id)
        {
            var request = new RestRequest(_apiUrls.GetAttributes(listing_id));
            var response = RestClient.Get< EtsyResponseModel < ListingAttribute >> (request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public EtsyResponseModel<ListingAttribute> UpdateAttribute(ListingAttribute attribute)
        {
            var request = new RestRequest(_apiUrls.UpdateAttribute(attribute.listing_id.GetValueOrDefault(), attribute.property_id));
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddObject(attribute);
            var response = RestClient.Put<EtsyResponseModel<ListingAttribute>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public EtsyResponseModel<ListingAttribute> DeleteAttribute(int listing_id, int property_id)
        {
            var request = new RestRequest(_apiUrls.DeleteAttribute(listing_id,property_id));
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            var response = RestClient.Delete<EtsyResponseModel<ListingAttribute>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public EtsyResponseModel<ListingImage> GetAllListingImages(long listingId)
        {
            var request = new RestRequest(_apiUrls.findAllListingImages(listingId));
            var response = RestClient.Get<EtsyResponseModel<ListingImage>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public EtsyResponseModel<ListingImage> DeleteListingImage(long listingId, long imageId)
        {
            var request = new RestRequest(_apiUrls.deleteListingImage(listingId, imageId));
            var response = RestClient.Delete<EtsyResponseModel<ListingImage>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public EtsyResponseModel<ListingImage> UploadListingImage (long listingId, byte[] fileBytes)
        {
            var request = new RestRequest(_apiUrls.uploadListingImage(listingId));
            request.AddFileBytes("image", fileBytes, "image", "multipart/form-dataheader");
            var response = RestClient.Post<EtsyResponseModel<ListingImage>>(request);
             CheckResponseSuccess(response);
            return response.Data;
        }
        public EtsyResponseModel<List<ListingImage>> UploadListingImageByUrl(long listingId, string image_url)
        {
            var request = new RestRequest(_apiUrls.uploadListingImage(listingId));
            WebClient wc = new WebClient();
            var bytes = wc.DownloadData(image_url);
            request.AddFileBytes("image", bytes, "image", "multipart/form-dataheader");
            var response = RestClient.Post<EtsyResponseModel<List<ListingImage>>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public VariationImage UploadListingInventoryImageByUrl(long listingId,string image_url,long propertyId,long valueId)
        {
            var request = new RestRequest(_apiUrls.uploadListingImage(listingId));
            WebClient wc = new WebClient();
            var bytes = wc.DownloadData(image_url);
            request.AddFileBytes("image", bytes, "image", "multipart/form-dataheader");
            var response = RestClient.Post<EtsyResponseModel<List<ListingImage>>>(request);
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
        public void LinkListingInventoryImages(long listingId,List<VariationImage> variationImages)
        {
            var request = new RestRequest(_apiUrls.updateVariantImages(listingId));
            request.AddObject(new
            {
                listing_id = listingId,
                variation_images = JsonConvert.SerializeObject(variationImages)
            });
            RestClient.Post(request);
        }
        public EtsyResponseModel<List<ListingImage>> UpdateVariationImages(ListingVariationImages listingVariantImages)
        {
            var request = new RestRequest(_apiUrls.updateVariantImages(listingVariantImages.listing_id));
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddObject(new
            {
              listing_id = listingVariantImages.listing_id,
              variation_images = JsonConvert.SerializeObject(listingVariantImages.variation_images.Where(x=>x.is_for_channel))
            });
            var response = RestClient.Post<EtsyResponseModel<List<ListingImage>>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public  EtsyResponseModel<List<EtsyProduct>> Update(EtsyProduct p)
        {
            var request = new RestRequest(_apiUrls.Update(p.listing_id));
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
            var response = RestClient.Put<EtsyResponseModel<List<EtsyProduct>>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
        public override EtsyResponseModel<EtsyProduct> Create(EtsyProduct p)
        {
            var request = new RestRequest(_apiUrls.Create());
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
            var response = RestClient.Post<EtsyResponseModel<EtsyProduct>>(request);
            CheckResponseSuccess(response);
            return response.Data;
        }
    }
}