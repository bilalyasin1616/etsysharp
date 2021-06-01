using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Etsysharp.Entities
{
    public class EtsyProduct : EtsyEntity
    {
        public long listing_id { get; set; }
        public string state { get; set; }
        public long? user_id { get; set; }
        public object category_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public long? creation_tsz { get; set; }
        public long? ending_tsz { get; set; }
        public long? original_creation_tsz { get; set; }
        public long? last_modified_tsz { get; set; }
        public string price { get; set; }
        public string currency_code { get; set; }
        public int? quantity { get; set; }
        public List<string> sku { get; set; }
        public List<string> tags { get; set; }
        public List<string> materials { get; set; }
        public object shop_section_id { get; set; }
        public object featured_rank { get; set; }
        public long? state_tsz { get; set; }
        public string url { get; set; }
        public long? views { get; set; }
        public long? num_favorers { get; set; }
        public long? shipping_template_id { get; set; }
        public long? processing_min { get; set; }
        public long? processing_max { get; set; }
        public string who_made { get; set; }
        public string is_supply { get; set; }
        public string when_made { get; set; }
        public string item_weight { get; set; }
        public string item_weight_unit { get; set; }
        public string item_length { get; set; }
        public string item_width { get; set; }
        public string item_height { get; set; }
        public string item_dimensions_unit { get; set; }
        public bool? is_private { get; set; }
        public object recipient { get; set; }
        public object occasion { get; set; }
        public object style { get; set; }
        public bool? non_taxable { get; set; }
        public bool? is_customizable { get; set; }
        public bool? is_digital { get; set; }
        public string file_data { get; set; }
        public bool? can_write_inventory { get; set; }
        public bool? should_auto_renew { get; set; }
        public string language { get; set; }
        public bool? has_variations { get; set; }
        public long taxonomy_id { get; set; }
        public List<string> taxonomy_path { get; set; }
        public bool? used_manufacturer { get; set; }
        public bool? is_vintage { get; set; }
        public User User { get; set; }
        public Shop Shop { get; set; }
        public object Section { get; set; }
        public List<Image> Images { get; set; }
        public Image MainImage { get; set; }
        public List<Shippinginfo> ShippingInfo { get; set; }
        public ListingInventory ListingInventory { get; set; }
        public List<VariantImageProperty> variantImageProperties { get; set; }
        public ShippingTemplate ShippingTemplate { get; set; }
        public List<object> ShippingUpgrades { get; set; }
        public Paymentinfo PaymentInfo { get; set; }
    }

    public class User : EtsyEntity
    {
        public long? user_id { get; set; }
        public string login_name { get; set; }
        public string primary_email { get; set; }
        public decimal? creation_tsz { get; set; }
        public User_Pub_Key user_pub_key { get; set; }
        public int referred_by_user_id { get; set; }
        public Feedback_Info feedback_info { get; set; }
        public long? awaiting_feedback_count { get; set; }
        public bool? use_new_inventory_endpoints { get; set; }
    }

    public class User_Pub_Key
    {
        public string key { get; set; }
        public long key_id { get; set; }
    }

    public class Feedback_Info
    {
        public long? count { get; set; }
        public object score { get; set; }
    }

    public class Shop: EtsyEntity
    {
        public long? shop_id { get; set; }
        public string shop_name { get; set; }
        public string first_line { get; set; }
        public string second_line { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public long? country_id { get; set; }
        public long? user_id { get; set; }
        public long? creation_tsz { get; set; }
        public string title { get; set; }
        public object announcement { get; set; }
        public string currency_code { get; set; }
        public bool? is_vacation { get; set; }
        public object vacation_message { get; set; }
        public object sale_message { get; set; }
        public object digital_sale_message { get; set; }
        public long? last_updated_tsz { get; set; }
        public long? listing_active_count { get; set; }
        public long? digital_listing_count { get; set; }
        public string login_name { get; set; }
        public long? lat { get; set; }
        public long? lon { get; set; }
        public bool? accepts_custom_requests { get; set; }
        public object policy_welcome { get; set; }
        public string policy_payment { get; set; }
        public string policy_shipping { get; set; }
        public string policy_refunds { get; set; }
        public string policy_additional { get; set; }
        public string policy_seller_info { get; set; }
        public object policy_updated_tsz { get; set; }
        public bool? policy_has_private_receipt_info { get; set; }
        public object vacation_autoreply { get; set; }
        public string ga_code { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public object image_url_760x100 { get; set; }
        public long? num_favorers { get; set; }
        public List<string> languages { get; set; }
        public object upcoming_local_event_id { get; set; }
        public string icon_url_fullxfull { get; set; }
        public bool? is_using_structured_policies { get; set; }
        public bool? has_onboarded_structured_policies { get; set; }
        public bool? has_unstructured_policies { get; set; }
        public bool? include_dispute_form_link { get; set; }
        public bool? use_new_inventory_endpoints { get; set; }
        public bool? is_direct_checkout_onboarded { get; set; }
        public string policy_privacy { get; set; }
        public bool? is_calculated_eligible { get; set; }
        public bool? is_opted_in_to_buyer_promise { get; set; }
        public bool? is_shop_us_based { get; set; }
    }

    public class Paymentinfo
    {
        public long? payment_template_id { get; set; }
        public bool? allow_bt { get; set; }
        public bool? allow_check { get; set; }
        public bool? allow_mo { get; set; }
        public bool? allow_other { get; set; }
        public bool? allow_paypal { get; set; }
        public bool? allow_cc { get; set; }
        public object paypal_email { get; set; }
        public object name { get; set; }
        public object first_line { get; set; }
        public object second_line { get; set; }
        public object city { get; set; }
        public object state { get; set; }
        public object zip { get; set; }
        public object country_id { get; set; }
        public long? user_id { get; set; }
        public long? listing_payment_id { get; set; }
    }

    public class Image
    {
        public long listing_image_id { get; set; }
        public string url_75x75 { get; set; }
        public string url_170x135 { get; set; }
        public string url_570xN { get; set; }
        public string url_fullxfull { get; set; }
        public long? full_height { get; set; }
        public long? full_width { get; set; }
    }

    public class Shippinginfo
    {
        public long? shipping_info_id { get; set; }
        public long? origin_country_id { get; set; }
        public long? destination_country_id { get; set; }
        public string currency_code { get; set; }
        public string primary_cost { get; set; }
        public string secondary_cost { get; set; }
        public long? listing_id { get; set; }
        public object region_id { get; set; }
        public string origin_country_name { get; set; }
        public string destination_country_name { get; set; }
    }
}
