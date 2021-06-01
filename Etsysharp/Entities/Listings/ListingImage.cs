using System;
using System.Collections.Generic;
using System.Text;

namespace Etsysharp.Entities
{
    public class ListingImage : EtsyEntity
    {
        public long listing_image_id { get; set; }
        public object hex_code { get; set; }
        public object red { get; set; }
        public object green { get; set; }
        public object blue { get; set; }
        public object hue { get; set; }
        public object saturation { get; set; }
        public object brightness { get; set; }
        public object is_black_and_white { get; set; }
        public int creation_tsz { get; set; }
        public int listing_id { get; set; }
        public int rank { get; set; }
        public string url_75x75 { get; set; }
        public string url_170x135 { get; set; }
        public string url_570xN { get; set; }
        public string url_fullxfull { get; set; }
        public object full_height { get; set; }
        public object full_width { get; set; }
    }
    public class VariationImage
    {
        public long property_id { get; set; }
        public long value_id { get; set; }
        public long image_id { get; set; }
        public string sku { get; set; }
        public string image_url { get; set; }
        public bool is_for_channel { get; set; }
    }
    public class ListingVariationImages
    {
        public long listing_id { get; set; }
        public List<VariationImage> variation_images { get; set; }
    }


}
