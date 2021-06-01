using System;
using System.Collections.Generic;
using System.Text;

namespace Etsysharp.Entities
{

    public class Country : EtsyEntity
    {
        public int country_id { get; set; }
        public string iso_country_code { get; set; }
        public string world_bank_country_code { get; set; }
        public string name { get; set; }
    }

}
