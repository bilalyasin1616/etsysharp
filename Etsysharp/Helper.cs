using System;

namespace Etsysharp
{
    public static class Helper
    {
        public static DateTime ConvertFromEpochTime(double seconds)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(seconds);
        }
    }
}
