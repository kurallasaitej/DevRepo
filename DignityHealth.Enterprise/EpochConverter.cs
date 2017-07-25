using System;

namespace Enterprise
{
    /// <summary>
    /// Has methods to convert epoch to human readable date and vice versa.
    /// </summary>
   public static class EpochConverter
    {
       /// <summary>
       /// Converts Epoch to datetime
       /// </summary>
       /// <param name="epoch"></param>
       /// <returns></returns>
        public static DateTime FromEpochTime(this long epoch)
        {
            var epochDate = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epochDate.AddSeconds(epoch);
        }

       /// <summary>
       /// Converts datetime to Epoch
       /// </summary>
       /// <param name="date"></param>
       /// <returns></returns>
        public static long ToEpochTime(this DateTime date)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return Convert.ToInt64((date.ToUniversalTime() - epoch).TotalSeconds);
        }
    }
}
