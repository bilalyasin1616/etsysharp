using System;
using System.Collections.Generic;
using System.Text;

namespace Etsysharp.Entities
{
    public class ListingAttribute
    {
        public long property_id { get; set; }
        public long? listing_id { get; set; }
        public string property_name { get; set; }
        public List<string> values { get; set; }
    }

}
