namespace Etsysharp.Entities
{
    public class EtsyFilter
    {
        public int Limit { get; set; }
        public int OffSet { get; set; }

        public EtsyFilter(int limit = 50, int offSet = 0)
        {
            Limit = limit;
            OffSet = offSet;
        }

    }

}
