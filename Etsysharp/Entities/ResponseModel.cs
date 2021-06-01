using System.Collections.Generic;

namespace Etsysharp.Entities
{
    public class EtsyResponseModel<T>
    {
        public EtsyResponseModel()
        {
        }

        public int? count { get; set; }
        public List<T> results { get; set; }
        public Params Params { get; set; }
        public Pagination pagination { get; set; }
    }
    public class Pagination
    {
        public int? effective_limit { get; set; }
        public int? effective_offset { get; set; }
        public int? next_offset { get; set; }
        public int? effective_page { get; set; }
        public int? next_page { get; set; }
    }
    public class Params
    {
        public int? limit { get; set; }
        public int? offset { get; set; }
        public object page { get; set; }
        public object keywords { get; set; }
        public string sort_on { get; set; }
        public string sort_order { get; set; }
        public object min_price { get; set; }
        public object max_price { get; set; }
        public object color { get; set; }
        public int? color_accuracy { get; set; }
        public object tags { get; set; }
        public object category { get; set; }
        public object location { get; set; }
        public object lat { get; set; }
        public object lon { get; set; }
        public object region { get; set; }
        public string geo_level { get; set; }
        public string accepts_gift_cards { get; set; }
        public string translate_keywords { get; set; }
    }

}
