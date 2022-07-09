using AuctionHome.Models;
using AuctionHome.Paging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionHome.Interfaces
{
    public interface IItem
    {
        Task<Item> getByID(int id);
        Task<Item> getByIDAsync(int id);
        Task<PagingItem> GetPagingItem(int currentPage);
        Task<bool> update(Item item);
        Task<bool> delete(Item item);
        Task<bool> deleteAll();
        Task<bool> create(Item item);
        Task<bool> updateDescription (Item item);
        Task<bool> updateWithoutImage (Item item);
        Task<bool> isMyItem(string usernameClaim, int id);
        long getAuctionTime(Item item);
       
    }
}
