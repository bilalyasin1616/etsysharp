using System;
using System.Collections.Generic;
using System.Text;

namespace Etsysharp.Entities
{

    public class ShippingTemplate : EtsyEntity
    {
        public long? shipping_template_id { get; set; }
        public string title { get; set; }
        public long? user_id { get; set; }
        public long? min_processing_days { get; set; }
        public long? max_processing_days { get; set; }
        public string processing_days_display_label { get; set; }
        public long? origin_country_id { get; set; }
        public List<ShippingTemplateEntry> Entries { get; set; }
        public string primary_cost { get; set; }
        public string secondary_cost { get; set; }
    }

    public class ShippingTemplateEntry
    {
        public long? shipping_template_entry_id { get; set; }
        public long? shipping_template_id { get; set; }
        public string currency_code { get; set; }
        public long? origin_country_id { get; set; }
        public long? destination_country_id { get; set; }
        public long? destination_region_id { get; set; }
        public string primary_cost { get; set; }
        public string secondary_cost { get; set; }
    }
}
