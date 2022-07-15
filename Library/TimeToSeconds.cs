using AuctionHome.Models;
using System;

namespace AuctionHome.Library
{
    public class TimeToSeconds
    {
        public long getDateTiemToSeconds(Item item)
        {
            long timetimeAuctionSeconds = -1;
            try
            {
                DateTime dateTimeNow = DateTime.Now;
                //Console.WriteLine(item.Auction2);
                //Console.WriteLine(dateTime);
                //Console.WriteLine((item.Auction2 - dateTime).Value);
                //Console.WriteLine((item.Auction2 - dateTime).Value.Days);
                //Console.WriteLine((item.Auction2 - dateTime).Value.Hours);
                //Console.WriteLine((item.Auction2 - dateTime).Value.Minutes);
                //Console.WriteLine((item.Auction2 - dateTime).Value.Seconds); *@
                if (item.Auction2 != null && item.Auction2 >= dateTimeNow)
                {
                    TimeSpan dateDate = ((TimeSpan)(item.Auction2 - dateTimeNow));
                    timetimeAuctionSeconds =
                        +dateDate.Days * 24*60*60
                        + dateDate.Hours * 60*60
                        + dateDate.Minutes * 60
                        + dateDate.Seconds;

                    // timetimeAuctionSeconds = long.Parse(date.ToString("yyyyMMddHHmmss"));
                    return timetimeAuctionSeconds;
                }
            }
            catch { return timetimeAuctionSeconds; }
            return timetimeAuctionSeconds;
        }
    }
}
