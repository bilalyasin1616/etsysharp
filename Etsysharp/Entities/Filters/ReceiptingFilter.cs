using System;
using System.Collections.Generic;
using System.Text;

namespace Etsysharp.Entities.Filters
{
    public class ReceiptingFilter : EtsyFilter
    {
        public string ShopIdOrName;
       
        public ReceiptingFilter(string shopIdOrName, int limit = 1, int offSet = 0)
        {
            ShopIdOrName = shopIdOrName;
            Limit = limit;
            OffSet = offSet;
        }
    }
}
