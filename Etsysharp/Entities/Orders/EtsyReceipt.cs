using System;
using System.Collections.Generic;
using System.Text;

namespace Etsysharp.Entities
{
    public class EtsyReceipt : ReceiptEntity
    {
        public long receipt_id { get; set; }
        public long? receipt_type { get; set; }
        public long? order_id { get; set; }
        public long? seller_user_id { get; set; }
        public long? buyer_user_id { get; set; }
        public decimal? creation_tsz { get; set; }
        public bool? can_refund { get; set; }
        public decimal? last_modified_tsz { get; set; }
        public string name { get; set; }
        public string first_line { get; set; }
        public string second_line { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
        public string formatted_address { get; set; }
        public long? country_id { get; set; }
        public string payment_method { get; set; }
        public string payment_email { get; set; }
        public string message_from_seller { get; set; }
        public string message_from_buyer { get; set; }
        public bool? was_paid { get; set; }
        public decimal? total_tax_cost { get; set; }
        public decimal? total_vat_cost { get; set; }
        public decimal? total_price { get; set; }
        public decimal? total_shipping_cost { get; set; }
        public string currency_code { get; set; }
        public string message_from_payment { get; set; }
        public bool? was_shipped { get; set; }
        public string buyer_email { get; set; }
        public string seller_email { get; set; }
        public bool? is_gift { get; set; }
        public bool? needs_gift_wrap { get; set; }
        public string gift_message { get; set; }
        public decimal? discount_amt { get; set; }
        public decimal? subtotal { get; set; }
        public decimal? grandtotal { get; set; }
        public decimal? adjusted_grandtotal { get; set; }
        public decimal? buyer_adjusted_grandtotal { get; set; }
        public List<ReceiptShipment> shipments { get; set; }
        public Country Country { get; set; }
        public User Buyer { get; set; }
        public User GuestBuyer { get; set; }
        public Seller Seller { get; set; }
        public List<Transaction> Transactions { get; set; }
        public List<EtsyProduct> Listings { get; set; }
        //undocumented fields
        public int? shipped_date { get; set; }
        public bool? is_overdue { get; set; }
        public int? days_from_due_date { get; set; }
        public string transparent_price_message { get; set; }
        public bool? show_channel_badge { get; set; }
        public string channel_badge_suffix_string { get; set; }
        public bool? is_dead { get; set; }
        public Shipping_Details shipping_details { get; set; }
    }

    
    public class ReceiptShipment
    {
        public string carrier_name { get; set; }
        public long? receipt_shipping_id { get; set; }
        public string tracking_code { get; set; }
        public string tracking_url { get; set; }
        public string buyer_note { get; set; }
        public int? notification_date { get; set; }
    }

    public class Shipping_Details
    {
        public bool? can_mark_as_shipped { get; set; }
        public bool? was_shipped { get; set; }
        public bool? is_future_shipment { get; set; }
        public bool? has_free_shipping_discount { get; set; }
        public string not_shipped_state_display { get; set; }
        public string shipping_method { get; set; }
        public bool? is_estimated_delivery_date_relevant { get; set; }
    }

    public class Buyer
    {
        public long guest_user_id { get; set; }
        public string real_name { get; set; }
        public string avatar_url { get; set; }
        public string login_name { get; set; }
    }

    public class Seller
    {
        public long user_id { get; set; }
        public string login_name { get; set; }
        public string primary_email { get; set; }
        public decimal? creation_tsz { get; set; }
        public Feedback_Info feedback_Info { get; set; }
        public object referred_by_user_id { get; set; }
        public long? awaiting_feedback_count { get; set; }
        public bool? use_new_inventory_endpoints { get; set; }
    }

 
    public class Transaction
    {
        public long transaction_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public long? seller_user_id { get; set; }
        public long? buyer_user_id { get; set; }
        public decimal? creation_tsz { get; set; }
        public decimal? paid_tsz { get; set; }
        public decimal? shipped_tsz { get; set; }
        public decimal? price { get; set; }
        public string currency_code { get; set; }
        public int? quantity { get; set; }
        public List<string> tags { get; set; }
        public List<string> materials { get; set; }
        public long? image_listing_id { get; set; }
        public long? receipt_id { get; set; }
        public decimal? shipping_cost { get; set; }
        public bool? is_digital { get; set; }
        public string file_data { get; set; }
        public long? listing_id { get; set; }
        public bool? is_quick_sale { get; set; }
        public long? seller_feedback_id { get; set; }
        public long? buyer_feedback_id { get; set; }
        public string transaction_type { get; set; }
        public string url { get; set; }
        public List<VariationInfo> variations { get; set; }
        public ListingProduct product_data { get; set; }
    }

    public class VariationInfo
    {
        public long property_id { get; set; }
        public long? value_id { get; set; }
        public string formatted_name { get; set; }
        public string formatted_value { get; set; }
    }


}
