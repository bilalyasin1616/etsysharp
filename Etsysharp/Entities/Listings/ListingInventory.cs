using System;
using System.Collections.Generic;
using System.Text;

namespace Etsysharp.Entities
{
    public class VariantImageProperty
    {
        public long property_id { get; set; }
        public long value_id { get; set; }
        public long image_id { get; set; }
    }

    public class BaseListingInventory
    {
        public List<long> price_on_property { get; set; }
        public List<long> quantity_on_property { get; set; }
        public List<long> sku_on_property { get; set; }
    }
    public class ListingInventory : BaseListingInventory
    {
        public List<ListingProduct> products { get; set; }
    }
    public class EtsyRequestListingInventory : BaseListingInventory
    {
        public List<EtsyRequestListingProduct> products { get; set; }
    }
    public class ListingProduct
    {
        public long product_id { get; set; }
        public string sku { get; set; }
        public List<PropertyValues> property_values { get; set; }
        public List<Offering> offerings { get; set; }
        public int is_deleted { get; set; }
    }

    public class EtsyRequestListingProduct
    {
        public long product_id { get; set; }
        public string sku { get; set; }
        public List<PropertyValues> property_values { get; set; }
        public List<EtsyRequestOffering> offerings { get; set; }
        public int is_deleted { get; set; }
    }

    public class PropertyValues
    {
        public long property_id { get; set; }
        public string property_name { get; set; }
        public long? scale_id { get; set; }
        public string scale_name { get; set; }
        public List<string> values { get; set; }
        public List<long> value_ids { get; set; }
    }

    public class Offering
    {
        public long offering_id { get; set; }
        public Price price { get; set; }
        public int quantity { get; set; }
        public int is_enabled { get; set; }
        public int is_deleted { get; set; }
    }

    public class EtsyRequestOffering
    {
        public long offering_id { get; set; }
        public string price { get; set; }
        public int quantity { get; set; }
        public int is_enabled { get; set; }
        public int is_deleted { get; set; }
    }
    public class Price
    {
        public decimal amount { get; set; }
        public decimal divisor { get; set; }
        public string currency_code { get; set; }
        public string currency_formatted_short { get; set; }
        public string currency_formatted_long { get; set; }
        public string currency_formatted_raw { get; set; }
    }
}
