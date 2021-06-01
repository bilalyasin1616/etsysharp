using System.Collections.Generic;

namespace Etsysharp.Entities
{
    public class EtsyList<T, F> : List<T> where F: EtsyFilter
    {
        private F _filter { get; set; }
        public int TotalCount { get; set; }

        public EtsyList(F filter, int totalCount, List<T> records)
        {
            _filter = filter;
            TotalCount = totalCount;
            AddRange(records);
        }

        public F GetNextPageFilter()
        {
            _filter.OffSet = _filter.OffSet + _filter.Limit;
            return _filter;
        }

        public bool HasNextPage()
        {
            int remaining=(TotalCount - (_filter.OffSet + _filter.Limit)) + _filter.Limit;
            if (remaining > 0)
                return true;
            return false;
        }
    }
}
