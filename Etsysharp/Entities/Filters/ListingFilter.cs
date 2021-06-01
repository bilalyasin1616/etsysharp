namespace Etsysharp.Entities.Filters
{
    public class ListingFilter: EtsyFilter
    {
        public string ShopIdOrName { get; set; }
        public string Status { get; set; }

        public ListingFilter(string shopIdOrName, string status, int limit = 1, int offSet = 0)
        {
            ShopIdOrName = shopIdOrName;
            Status = status;
            Limit = limit;
            OffSet = offSet;
        }
    }
}
