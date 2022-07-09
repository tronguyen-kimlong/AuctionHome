using AuctionHome.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuctionHome.Interfaces
{
    public interface IListAuctioning
    {
        Task<ListAuctioning> getByID(int id);
        Task<List<ListAuctioning>> getAll();

        Task<bool> update(ListAuctioning listAuctioning);
        Task<bool> delete(ListAuctioning listAuctioning);
        Task<bool> deleteAll();
        Task<bool> create(ListAuctioning listAuctioning);
    }
}
