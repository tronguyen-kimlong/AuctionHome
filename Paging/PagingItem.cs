using AuctionHome.Models;
using System.Collections.Generic;

namespace AuctionHome.Paging
{
    public class PagingItem
    {
        public List<Item> Items { get; set; }
        public int PageIndex { get; set; }
        public int PageTotal { get; set; }
        
    }
}
