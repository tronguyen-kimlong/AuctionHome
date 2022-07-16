using AuctionHome.Models;
using AuctionHome.Paging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionHome.Interfaces
{
    public interface IItem
    {
        Task<Item> getByID(int id);
        Task<Item> getByIDAsync(int id);
        Task<PagingItem> GetPagingItem(
            int currentPage = 0,
            bool isAccept = true,
            bool auction = true,
            bool isSold = false,
            bool isPaid = false
            );
        Task<PagingItem> MyItems(int currentPage, string username);
        Task<PagingItem> MyItemsIsAccept(int currentPage, string username, bool isAccept);
        Task<PagingItem> MyItemsIsSold(int currentPage, string username, bool isSold);
        Task<PagingItem> MyItemsIsPaid(int currentPage, string username, bool isPaid);
        Task<PagingItem> MyItemsIsAuction(int currentPage, string username, bool isSold);
        Task<PagingItem> MyItemsReadyAuction(int currentPage, string username, bool accepted);
        Task<bool> update(Item item);
        Task<bool> delete(Item item);
        Task<bool> deleteAll();
        Task<bool> create(Item item);
        Task<bool> updateDescription (Item item);
        Task<bool> updateWithoutImage (Item item);
        Task<bool> updateTimeAuction(Item item, DateTime timeAuction); 
        Task<bool> isMyItem(string usernameClaim, int id);
        long getAuctionTime(Item item);
        Task<bool> updatePriceAuction(Item item, decimal priceAuction);
        Task<bool> setAccept(Item item);
        Task<bool> setSold(Item item);
        Task<bool> setPaid(Item item);

       
    }
}
