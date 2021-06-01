using System;
using System.Collections.Generic;
using System.Text;

namespace Etsysharp.Entities
{
    public class ApiUrls
    {
        public static readonly string baseUrl = "https://openapi.etsy.com/v2/";
        public static readonly string GetTaxonomy = "taxonomy/seller/get";
        public static readonly string GetCountries= "countries";
        public static class OAuthUrls
        {
            public static readonly string requestToken = "oauth/request_token";
            public static readonly string accessToken = "oauth/access_token";

        }
        public class CartUrl
        {
            public static readonly string Includes = "Listings,ShippingOptions";
            public static  string GetAllUserCarts(long userId) => $"/users/{userId}/carts";
        }
        public class ReceiptUrl
        {
            public static readonly string Includes = "Listings,Country,Buyer,GuestBuyer,Seller,Transactions";
            public static string GetAllShopReceipts(string shopIdOrName) => $"/shops/{shopIdOrName}/receipts";
            public static string UpdateReceipt(long receiptId) => $"/receipts/{receiptId}";
            public static string SubmitTracking(string shopIdOrName,long receiptId) => $"/shops/{shopIdOrName}/receipts/{receiptId}/tracking";
        }
        public virtual string Create() => "";
        public virtual string Update(long id) => "";
        public virtual string Delete(long id) => "";
        public virtual string Get(long id) => "";
        public virtual string GetAll(string status) => "";
    }
    public class ListingUrls : ApiUrls
    {
        public string Includes = "User,Shop,Section,Images,MainImage,ShippingInfo,ShippingTemplate,ShippingUpgrades,PaymentInfo";
        public override string Delete(long id) => $"listings/{id}";
        public override string GetAll(string status) => $"listings/{status}";
        public override string Get(long id) => $"listings/{id}";
        public string FindAllShopListingDraft(string shopIdOrName, string status) => $"shops/{shopIdOrName}/listings/{status}";
        public override string Update(long id) => $"listings/{id}";
        public override string Create() => "listings";
        public string GetInventory(long listing_id) => $"listings/{listing_id}/inventory";
        public string UpdateInventory(long listing_id) => $"listings/{listing_id}/inventory";
        public string GetAttributes(long listing_id) => $"listings/{listing_id}/attributes";
        public string UpdateAttribute(long listing_id, long property_id) => $"listings/{listing_id}/attributes/{property_id}";
        public string DeleteAttribute(long listing_id, long property_id) => $"/listings/{listing_id}/attributes/{property_id}";
        public  string findAllListingImages(long listingid) => $"/listings/{listingid}/images";
        public  string deleteListingImage(long listingId, long imageId) => $"listings/{listingId}/images/{imageId}";
        public  string uploadListingImage(long listingId) => $"listings/{listingId}/images";
        public  string updateVariantImages(long listingId) => $"listings/{listingId}/variation-images";
        public string getVariantImages(long listingId) => $"listings/{listingId}/variation-images";
    }
    public class ListingImageUrls
    {


    }
    public class ListingInventoryUrls
    {
        public static string Update(long id) => $"/listings/{id}/inventory";
        public static string Get(long id) => $"listings/{id}/inventory";
    }

    public class UserUrls : ApiUrls
    {
        public static string OauthScopes() => "oauth/scopes";
        public override string GetAll(string status) => "users";
    }
    public class ShopUrls : ApiUrls
    {
        public override string GetAll(string status) => "shops";
        public static string Get(string name) => $"shops/{name}";
        public static string FindAllUserShops(string username) => $"users/{username}/shops";
    }

    public class ShippingTemplateUrls : ApiUrls
    {
        public string Includes = "Entries,Upgrades";
        public override string Delete(long id) => $"shipping/templates/{id}";
        public override string GetAll(string userId) => $"users/{userId}/shipping/templates";
        public override string Get(long id) => $"shipping/templates/{id}";
        public string FindAllShopListingDraft(string shopIdOrName, string status) => $"shops/{shopIdOrName}/listings/{status}";
        public override string Update(long id) => $"shipping/templates/{id}";
        public override string Create() => "shipping/templates";
    }

    public class PaymentTemplateUrls : ApiUrls
    {
        public override string GetAll(string userId) => $"users/{userId}/payments/templates";
        public string FindAllShopListingDraft(string shopIdOrName, string status) => $"shops/{shopIdOrName}/listings/{status}";
    }
}